using System;
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
            DownloadBundleAndLoadScene (ToLoadSceneName);

    }

    public void DownloadBundleAndLoadScene (string sceneName)
    {
        var item = new BundleCacheItem (ToLoadSceneName.ToLower ());
        StartCoroutine (AssetBundleManager.Instance.CheckDownloadBundleFromRemoteServer (item,
            () =>
            {
                SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
            },
            null, 
            DownloadingAssetbundle
        ));

    }

    private void DownloadingAssetbundle (float process)
    {
        Log.Print (process.ToString ());
        SliderImage.fillAmount = process;
    }

}