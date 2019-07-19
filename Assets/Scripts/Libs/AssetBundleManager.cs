using System;
using System.Collections.Generic;
using System.IO;
/*
 * @Descripttion: Load Asssetbundle
 * @version: 0.0.1
 * @Author: Darcy
 * @Date: 2019-07-19 14:38:57
 * @LastEditTime: 2019-07-19 21:05:49
 */
using UnityEngine;

namespace Libs
{
    public class AssetBundleManager
    {

        public static AssetBundleManager Instance
        {
            get
            {
                return Singleton<AssetBundleManager>.Instance;
            }
        }
        private AssetBundleManager () { }

        private Dictionary<String, AssetBundle> bundles = new Dictionary<String, AssetBundle> ();

        /// <summary>
        /// check bundle exist and load
        /// </summary>
        /// <param name="bundleName"></param>
        /// <returns></returns>
        public bool CheckLoadBundle (string bundleName)
        {
            if (string.IsNullOrEmpty (bundleName))
            {
                Log.Error ("Bundle name error", bundleName);
                return false;
            }

#if UNITY_IPHONE
            string path = Path.Combine (AssetPathManager.GetAssetBundleOutPutPath (), bundleName);
            if (File.Exists (path))
            {
                if (bundles.ContainsKey (bundleName) && bundles[bundleName] == null)
                {
                    bundles[bundleName] = AssetBundle.LoadFromFile (path);
                }
                else if (!bundles.ContainsKey (bundleName))
                    bundles.Add (bundleName, AssetBundle.LoadFromFile (path));
                return true;
            }
            else
            {
                Log.Error ("Bundle Path not exist", bundleName);
                return false;
            }
#endif

        }

        /// <summary>
        /// 卸载bundle中所有的assets
        /// </summary>
        /// <param name="bundleName"></param>
        /// <param name="unloadAllLoadedObjs">默认为false</param>
        public void UnLoadBundle (string bundleName, bool unLoadAllLoadedObjs = false)
        {
            if (bundles.ContainsKey (bundleName) && bundles[bundleName] != null)
                bundles[bundleName].Unload (unLoadAllLoadedObjs); //* */这里传入true则bundle内资源创建的实例也会被destroy掉，比如加载了一个图片在一个场景内，这时候卸载bundle并传入true  这个图片也会消失
        }

        public Sprite LoadSpriteFromBundle (string spriteName, string bundleName)
        {
            AssetBundle bundle;
            if (bundles.ContainsKey (bundleName) && bundles[bundleName] != null)
                bundle = bundles[bundleName];
            else
            {
                Log.Error ("Bundle not exist", bundleName);
                return null;
            }

            var result = bundle.LoadAsset<Sprite> (spriteName);
            if (result == null)
            {
                Log.Error ("Sprite is not exist >> ", spriteName);
                return null;
            }

            return result;
        }

    }

    public enum BundleType
    {
        Default,
        Wys,
    }

}