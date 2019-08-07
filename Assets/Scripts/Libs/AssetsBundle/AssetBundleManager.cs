using System.Linq;
using System.Net;
/*
 * @Descripttion: Load Asssetbundle
 * @version: 0.0.1
 * @Author: Darcy
 * @Date: 2019-07-19 14:38:57
 * @LastEditTime: 2019-08-07 15:20:01
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Libs;
using UnityEngine;
using UnityEngine.Networking;

namespace AssetBundleLibs
{

    public class AssetBundleManager
    {
        #region Instance
        public static AssetBundleManager Instance
        {
            get
            {
                return Singleton<AssetBundleManager>.Instance;
            }
        }
        private AssetBundleManager () { }
        #endregion

        private Dictionary<String, AssetBundle> bundleCaches = new Dictionary<String, AssetBundle> ();
        private Dictionary<String, UnityWebRequest> bundleWebRequests = new Dictionary<string, UnityWebRequest> ();
        private Dictionary<String, AssetBundleCreateRequest> bundleCreateRequests = new Dictionary<string, AssetBundleCreateRequest> ();

        private string _bundlDownloadUrl;

        #region Public Func

        public void Init (string bundleLoadUrl)
        {
            _bundlDownloadUrl = bundleLoadUrl;
        }

        /// <summary>
        /// check bundle exist and load
        /// </summary>
        /// <param name="bundleName"></param>
        /// <returns></returns>
        public IEnumerator CheckLoadBundleFromLocalFile (string bundleName,
            Action loadSucceedCallBack = null,
            Action loadFailedCallBack = null,
            Action<float> loadingCallBack = null)
        {

            if (string.IsNullOrEmpty (bundleName))
            {
                Log.Error ("Bundle name error", bundleName);
                loadFailedCallBack?.Invoke ();
                yield break;
            }

            if (!IsBundleExistInCache (bundleName))
            {
                string path = Path.Combine (AssetPathManager.GetAssetBundleOutPutPath (), bundleName);
                if (File.Exists (path))
                {
                    var _bundeCreateRequest = new AssetBundleCreateRequest ();
                    bundleCreateRequests.Add (bundleName, _bundeCreateRequest);

                    _bundeCreateRequest = AssetBundle.LoadFromFileAsync (path);

                    int displayProgress = 1;
                    int toProgress = 0;
                    while (!_bundeCreateRequest.isDone)
                    {

                        toProgress = (int) (100 * _bundeCreateRequest.progress);
                        while (displayProgress <= toProgress)
                        {
                            loadingCallBack?.Invoke ((float) displayProgress / 100.0f);
                            yield return GameConstants.Wait1In60Second;
                            displayProgress++;
                        }
                        yield return GameConstants.Wait1In60Second;
                    }
                    toProgress = 100;
                    while (displayProgress <= toProgress)
                    {
                        loadingCallBack?.Invoke ((float) displayProgress / 100.0f);
                        yield return GameConstants.Wait1In60Second;
                        displayProgress++;
                    }

                    if (_bundeCreateRequest.assetBundle != null)
                    {
                        AddBundleCache (_bundeCreateRequest.assetBundle);
                        loadSucceedCallBack?.Invoke ();
                    }
                    else
                    {
                        loadFailedCallBack?.Invoke ();
                    }
                    bundleCreateRequests.Remove (bundleName);
                }
                else
                {
                    Log.Error ("Bundle not exist", bundleName);
                    loadFailedCallBack?.Invoke ();
                    yield break;
                }
            }
            else
            {
                loadSucceedCallBack?.Invoke ();
            }
        }

        /// <summary>
        ///  从远程下载bundle
        /// ! 测试使用mac本地服务器 url地址配置在GameCanstants中
        /// </summary>
        /// <param name="bundleName"></param>
        /// <param name="downloadSucceedCallBack"></param>
        /// <param name="downloadFailedCallBack">范</param>
        /// <returns></returns>
        public IEnumerator CheckDownloadBundleFromRemoteServer (BundleCacheItem cacheItem, Action downloadSucceedCallBack = null, Action downloadFailedCallBack = null, Action<float> downloadingCallBack = null)
        {
            if (!cacheItem.NeedDownload ())
            {
                downloadSucceedCallBack?.Invoke ();
                yield break;
            }

            string _bundleName = cacheItem.BundleName;

            string downloadUrl = GetBundleRemoteUrl (_bundleName, cacheItem.BundleVersion);
            if (string.IsNullOrEmpty (downloadUrl))
                yield break;

            UnityEngine.Networking.UnityWebRequest request = UnityWebRequest.Get (downloadUrl);
            request.timeout = 600;
            bundleWebRequests.Add (_bundleName, request);
            request.SendWebRequest ();

            int displayProgress = 1;
            int toProgress = 0;
            while (!request.isDone)
            {
                toProgress = (int) (100 * request.downloadProgress);
                while (displayProgress <= toProgress)
                {

                    downloadingCallBack?.Invoke ((float) displayProgress / 100.0f);
                    yield return GameConstants.Wait1In60Second;
                    displayProgress++;
                }
                yield return GameConstants.Wait1In60Second;
            }
            toProgress = 100;
            while (displayProgress <= toProgress)
            {
                downloadingCallBack?.Invoke ((float) displayProgress / 100.0f);
                yield return GameConstants.Wait1In60Second;
                displayProgress++;
            }

            if (request.isHttpError || request.isNetworkError)
            {
                Log.Error (request.error);
                //TODO display dialog
                yield break;
            }

            string localSavePath = Path.Combine (AssetPathManager.GetAssetBundleOutPutPath (), cacheItem.BundleName);
            //*删除旧版本bundle */
            try
            {
                string dicPath = Path.GetDirectoryName (localSavePath);
                if (!Directory.Exists (dicPath))
                {
                    Directory.CreateDirectory (dicPath);
                    File.Delete (localSavePath);
                }

            }
            catch (Exception ex)
            {
                Log.Error (ex.Message);
            }

            var data = request.downloadHandler.data;

            try
            {
                string dicPath = Path.GetDirectoryName (localSavePath);
                if (!Directory.Exists (dicPath))
                {
                    Directory.CreateDirectory (dicPath);
                }
                File.WriteAllBytes (localSavePath, data);
            }
            catch (Exception e)
            {
                Log.Error (e.Message);
            }
            // yield return GameConstants.Wait2In10Second;
            bundleWebRequests.Remove (_bundleName);
            request.Dispose ();
            downloadSucceedCallBack?.Invoke();
        }

        /// <summary>
        /// 卸载bundle中所有的assets
        /// </summary>
        /// <param name="bundleName"></param>
        /// <param name="unloadAllLoadedObjs">默认为false</param>
        public void UnLoadBundle (string bundleName, bool unLoadAllLoadedObjs = false)
        {
            if (bundleCaches.ContainsKey (bundleName) && bundleCaches[bundleName] != null)
            {
                bundleCaches[bundleName].Unload (unLoadAllLoadedObjs); //* */这里传入true则bundle内资源创建的实例也会被destroy掉，比如加载了一个图片在一个场景内，这时候卸载bundle并传入true  这个图片也会消失
                bundleCaches.Remove (bundleName);
            }
        }

        public bool NeedDownloadNewAssetbundle (BundleCacheItem item)
        {

            if (!CheckBundleExistInLocalFile (item.BundleName))
                return true;

            if (!string.IsNullOrEmpty (item.BundleVersion))
            {
                //TODO compare is item.version same as localversion
                return true;
            }
            return false;
        }

        public bool CheckBundleExistInLocalFile (string name)
        {
            return File.Exists (Path.Combine (AssetPathManager.GetAssetBundleOutPutPath (), name));
        }

        public T LoadResourceFromBundle<T> (string resourceName, string bundleName) where T : UnityEngine.Object
        {
            AssetBundle bundle;
            if (IsBundleExistInCache (bundleName))
                bundle = bundleCaches[bundleName];
            else
            {
                Log.Error ("Bundle not exist", bundleName);
                return null;
            }

            var result = bundle.LoadAsset<T> (resourceName);
            if (result == null)
            {
                Log.Error ("Resource is not exist", resourceName);
                return null;
            }

            return result;
        }

        public UnityWebRequest GetBundleWebRequestByName (string name)
        {
            if (bundleWebRequests.ContainsKey (name))
                return bundleWebRequests[name];
            return null;
        }

        public AssetBundleCreateRequest GetBundleLoadRequestByName (string name)
        {
            if (bundleCreateRequests.ContainsKey (name))
                return bundleCreateRequests[name];
            return null;
        }

        #endregion

        #region Internal Util Func

        private bool IsBundleExistInCache (string name)
        {
            return (bundleCaches.ContainsKey (name) && bundleCaches[name] != null);
        }

        private string GetAssetbundleLocalSavaPath (string bundleName)
        {
            return Path.Combine (UnityUtil.persistentDataPath, bundleName);
        }

        private string GetBundleRemoteUrl (string bundleName, string version)
        {
            return Path.Combine (_bundlDownloadUrl, AssetPathManager.GetPlatformName (), version, bundleName);
        }

        private void AddBundleCache (AssetBundle bundle)
        {
            if (bundle != null && !bundleCaches.ContainsKey (bundle.name))
                bundleCaches.Add (bundle.name, bundle);
        }

        #endregion

    }

    public enum BundleType
    {
        Default,
        Wys,
    }

}