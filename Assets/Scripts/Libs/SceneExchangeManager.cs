/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-20 14:18:45
 * @LastEditTime: 2019-07-20 17:12:09
 */
using System;
using AssetBundleLibs;
using Libs;
namespace Libs
{
    public class SceneExchangeManager
    {

        #region Instance    
        public static SceneExchangeManager Instance
        {
            get
            {
                return Singleton<SceneExchangeManager>.Instance;
            }
        }
        private SceneExchangeManager () { }
        #endregion

        /// <summary>
        /// 切换场景卸载加载资源 显示loadding界面等
        /// todo loading is to be achieved
        /// </summary>
        /// <param name="currentScene"></param>
        /// <param name="newScene"></param>
        /// <returns></returns>
        public bool SceneExchange (string currentScene, string newScene)
        {
            if (newScene.Equals (GameConstants.MAIN_SCENE_NAME))
            {
                UnloadCurrentSceneBundle (currentScene);
                return true;
            }
            if (!CheckCanLoadSceneFromLocal (newScene))
                return false;
            UnloadCurrentSceneBundle (currentScene);
            LoadNewSceneBundle (newScene);
            return true;
        }

        #region Internal func
        private void UnloadCurrentSceneBundle (string currentScene)
        {
            if (string.IsNullOrEmpty (currentScene))
                return;
            AssetBundleManager.Instance.UnLoadBundle (currentScene.ToLower (), true);
        }

        private void LoadNewSceneBundle (string newScene)
        {
            AssetBundleManager.Instance.CheckLoadBundleFromLocalFile (newScene);
        }

        private bool CheckCanLoadSceneFromLocal (string sceneName)
        {
            return AssetBundleManager.Instance.CheckBundleExistInLocalFile (sceneName.ToLower ());
        }

        #endregion

    }
}