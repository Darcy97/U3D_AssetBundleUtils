/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-19 15:11:41
 * @LastEditTime: 2019-08-07 12:22:50
 */

using UnityEngine;
using UnityEngine.SceneManagement;
namespace Libs
{
    public class SceneLoadManager : MonoBehaviour
    {

        #region Singleton
        public static SceneLoadManager Instance
        {
            get
            {
                return Singleton<SceneLoadManager>.Instance;
            }
        }

        private SceneLoadManager () { }
        #endregion

        private string _currentScene;

        public void LoadScene (string name)
        {
            SceneExchangeManager.Instance.SceneExchange (_currentScene, name,
                () =>
                {
                    _currentScene = name;
                    AsyncOperation operation = SceneManager.LoadSceneAsync (name);
                });
        }

        public string GetCurrentSceneName ()
        {
            return _currentScene;
        }

    }
}