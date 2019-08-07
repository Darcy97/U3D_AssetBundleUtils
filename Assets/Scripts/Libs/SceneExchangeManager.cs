using System;
using System.Net.Mime;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-20 14:18:45
 * @LastEditTime: 2019-08-07 14:31:18
 */
using System.Collections;
using AssetBundleLibs;
using Libs;
using UnityEngine;
using UnityEngine.UI;
namespace Libs
{
    public class SceneExchangeManager : MonoBehaviour
    {

        #region Instance    
        public static SceneExchangeManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                    
                _instance = GameObject.FindObjectOfType<SceneExchangeManager> ();
                return _instance;
            }
            private set{}
        }

        public static SceneExchangeManager _instance;
        private SceneExchangeManager () { }
        #endregion

        public Image BundleLoadSlider;
        private void Awake ()
        {

            if (_instance == null)
            {
                _instance = this;
                
            }
            else if (_instance != this)
            {
                Destroy (this.gameObject);
            }

        }

        /// <summary>
        /// 切换场景卸载加载资源 显示loadding界面等
        /// todo loading is to be achieved
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="newScene"></param>
        /// <returns></returns>
        public bool SceneExchange (string currentScene, string newScene, Action succeedCallBack = null)
        {
            if (newScene.Equals (GameConstants.MAIN_SCENE_NAME))
            {
                UnloadCurrentSceneBundle (currentScene);
                return true;
            }
            if (!CheckCanLoadSceneFromLocal (newScene))
                return false;
            UnloadCurrentSceneBundle (currentScene);
            LoadNewSceneBundle (newScene, succeedCallBack);
            return true;
        }

        #region Internal func
        private void UnloadCurrentSceneBundle (string currentScene)
        {
            if (string.IsNullOrEmpty (currentScene))
                return;
            AssetBundleManager.Instance.UnLoadBundle (currentScene.ToLower (), true);
        }

        private void LoadNewSceneBundle (string newScene, Action succeedCallBack = null)
        {
            if (succeedCallBack == null)
            {
                Log.Error ("null");
            }
            // AssetBundleManager.Instance.CheckLoadBundleFromLocalFile (newScene);
            LoadBundle (newScene.ToLower (), succeedCallBack);
        }

        private bool CheckCanLoadSceneFromLocal (string sceneName)
        {
            return AssetBundleManager.Instance.CheckBundleExistInLocalFile (sceneName.ToLower ());
        }

        public void LoadBundle (string bundleName, Action succeedCallBack = null)
        {
            CoroutineUtil.Instance.StartCoroutine (
                AssetBundleManager.Instance.CheckLoadBundleFromLocalFile (
                    bundleName,
                    succeedCallBack,
                    null,
                    LoadingBundle));
        }

        private void LoadingBundle (float progress)
        {
            Log.Print (progress.ToString ());
            BundleLoadSlider.fillAmount = progress;
        }

        #endregion

    }
}