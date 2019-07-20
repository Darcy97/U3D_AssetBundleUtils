using System.Collections;
using System.Collections;
using AssetBundleLibs;
using Libs;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{

    public string ToLoadSceneName;

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

        yield return new WaitUntil (() => AssetBundleManager.Instance.GetRequestByBundleName (sceneName.ToLower ()) != null);

        var request = AssetBundleManager.Instance.GetRequestByBundleName (sceneName.ToLower ());
        while (request != null && !request.isDone)
        {
            Log.Print (request.downloadProgress.ToString ());
            yield return GameConstants.WaitTwoIn10Second;
        }

        SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
    }

}