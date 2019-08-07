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

    private void DownloadingAssetbundle (float progress)
    {
        Log.Print (progress.ToString ());
        SliderImage.fillAmount = progress;
    }

}