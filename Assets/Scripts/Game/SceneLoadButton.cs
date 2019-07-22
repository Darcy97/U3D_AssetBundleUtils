using System.Collections;
using System.Collections;
using AssetBundleLibs;
using Libs;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
    {

        public string ToLoadSceneName;
        public Image SliderImage;

        private void Awake ()
        {
            GetComponent<Button> ().onClick.AddListener (OnButtonClick);
        }

        private Coroutine _bundleDownloadCoroutine;
        public void OnButtonClick ()
        {
            if (AssetBundleManager.Instance.CheckBundleExistInLocalFile (ToLoadSceneName.ToLower ()))
                SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
            else
                _bundleDownloadCoroutine = StartCoroutine (DownloadBundleAndLoadScene (ToLoadSceneName));

        }

        public IEnumerator DownloadBundleAndLoadScene (string sceneName)
        {
            var item = new BundleCacheItem (ToLoadSceneName.ToLower ());
            StartCoroutine (AssetBundleManager.Instance.CheckDownloadBundleFromRemoteServer (item, null, 
            () =>
                {
                    if (_bundleDownloadCoroutine != null)
                    {
                        StopCoroutine (_bundleDownloadCoroutine);
                    }
                }));

                //TODO 如果上面协程启动 request 失败 这里会卡住
                //TODO 拟通过获取本协程索引 通过关闭协程结束下面的逻辑
                yield return new WaitUntil (() => AssetBundleManager.Instance.GetBundleWebRequestByName (sceneName.ToLower ()) != null);

                var request = AssetBundleManager.Instance.GetBundleWebRequestByName (sceneName.ToLower ());
                while (request != null && !request.isDone)
                {
                    Log.Print (request.downloadProgress.ToString ());
                    SliderImage.fillAmount = request.downloadProgress;
                    yield return GameConstants.WaitTwoIn100Second;
                }

                SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
            }

        }