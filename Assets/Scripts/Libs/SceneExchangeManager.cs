using System;
using System.Net.Mime;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-20 14:18:45
 * @LastEditTime: 2019-07-22 16:17:08
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
                return Singleton<SceneExchangeManager>.Instance;
            }
        }
        private SceneExchangeManager () { }
        #endregion

        public Image BundleLoadSlider;

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

        private Coroutine _bundleLoadCoroutine;
        private void LoadNewSceneBundle (string newScene, Action succeedCallBack = null)
        {
            if(succeedCallBack == null){
                Log.Error("null");
            }
            // AssetBundleManager.Instance.CheckLoadBundleFromLocalFile (newScene);
            _bundleLoadCoroutine = CoroutineUtil.Instance.StartCoroutine((LoadBundle (newScene.ToLower (), succeedCallBack)));
        }

        private bool CheckCanLoadSceneFromLocal (string sceneName)
        {
            return AssetBundleManager.Instance.CheckBundleExistInLocalFile (sceneName.ToLower ());
        }

        public IEnumerator LoadBundle (string bundleName, Action succeedCallBack = null)
        {
            CoroutineUtil.Instance.StartCoroutine (AssetBundleManager.Instance.CheckLoadBundleFromLocalFile (bundleName, succeedCallBack, ()=>{
                if(_bundleLoadCoroutine != null)
                StopCoroutine(_bundleLoadCoroutine);
            }));

            //TODO 如果上面协程启动 request 失败 这里会卡住
            //TODO 拟通过获取本协程索引 通过关闭协程结束下面的逻辑
            yield return new WaitUntil (() =>
                AssetBundleManager.Instance.GetBundleLoadRequestByName (bundleName) != null);
            var request = AssetBundleManager.Instance.GetBundleLoadRequestByName (bundleName);
            //TODO request报空问题待解决
            while (request != null && !request.isDone)
            {
                Log.Print (request.progress.ToString ());
                BundleLoadSlider.fillAmount = request.progress;
                yield return GameConstants.WaitTwoIn100Second;
            }

            yield return 0;
        }

        #endregion

    }
}