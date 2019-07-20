/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-20 14:04:48
 * @LastEditTime: 2019-07-20 15:15:37
 */
using System;
using Libs;
namespace AssetBundleLibs
{
    public class BundleCacheItem
    {
        public string BundleName { get; set; }
        public string BundleVersion { get; set; }
        public Action<bool> LoadFinishCallBack { get; set; }

        public BundleCacheItem (string _bundleName, string _version = "0.0.0", Action<bool> _finishCallBack = null)
        {
            BundleName = _bundleName;
            BundleVersion = _version;
            LoadFinishCallBack = _finishCallBack;
        }
        public bool NeedDownload ()
        {
            if (!CanDownload ())
            {
                Log.Error ("Can not download", this.BundleName);
                return false;
            }

            if (!string.IsNullOrEmpty (BundleVersion))
            {
                return AssetBundleManager.Instance.NeedDownloadNewAssetbundle (this);
            }
            return false;
        }

        public bool CanDownload ()
        {
            return !string.IsNullOrEmpty (BundleName);
        }
    }
}