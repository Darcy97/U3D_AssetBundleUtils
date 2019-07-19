/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-19 15:11:41
 * @LastEditTime: 2019-07-19 20:20:09
 */

using UnityEngine;
using UnityEngine.SceneManagement;
namespace Libs
{
    public class SceneLoadManager
    {

        public static SceneLoadManager Instance
        {
            get
            {
                return Singleton<SceneLoadManager>.Instance;
            }
        }

        private SceneLoadManager(){}

        private string _currentScene;

        public void LoadScene (string name)
        {
            _currentScene = name;
            AsyncOperation operation = SceneManager.LoadSceneAsync (name);
        }

        public string GetCurrentSceneName ()
        {
            return _currentScene;
        }

    }
}