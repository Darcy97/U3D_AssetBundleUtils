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

    public void OnButtonClick ()
    {
        if (AssetBundleManager.Instance.CheckBundleExistInLocalFile (ToLoadSceneName.ToLower ()))
            SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
        else
            StartCoroutine (DownloadBundleAndLoadScene (ToLoadSceneName));

    }

    public IEnumerator DownloadBundleAndLoadScene (string sceneName)
    {
        StartCoroutine (AssetBundleManager.Instance.CheckDownloadBundleFromRemoteServer (new BundleCacheItem (ToLoadSceneName.ToLower ())));

        //TODO 如果上面协程启动 request 失败 这里会卡住
        //TODO 拟通过获取本协程索引 通过关闭协程结束下面的逻辑
        yield return new WaitUntil (() => AssetBundleManager.Instance.GetRequestByBundleName (sceneName.ToLower ()) != null);

        var request = AssetBundleManager.Instance.GetRequestByBundleName (sceneName.ToLower ());
        while (request != null && !request.isDone)
        {
            Log.Print (request.downloadProgress.ToString ());
            SliderImage.fillAmount = request.downloadProgress;
            yield return GameConstants.WaitTwoIn100Second;
        }

        SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
    }

}