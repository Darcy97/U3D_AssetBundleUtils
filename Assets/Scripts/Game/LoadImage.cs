using System;
using System.Collections.Generic;
using System.Linq;
using AssetBundleLibs;
using Libs;
using UnityEngine;
using UnityEngine.UI;

public class LoadImage : MonoBehaviour
{

    public int img_index;

    private Image _image;
    private string _bundleName;
    private List<string> _imgNames;

    private void Awake ()
    {
        _image = GetComponent<Image> ();
        _bundleName = SceneLoadManager.Instance.GetCurrentSceneName ();
        if (!string.IsNullOrEmpty (_bundleName))
            _bundleName = _bundleName.ToLower ();

        if (_bundleName == GameConstants.WYS_SCENE_NAME.ToLower ())
            _imgNames = GameConstants.WYS_IMG_NAME_ARRAY.ToList ();
        else if (_bundleName == GameConstants.IRVUE_SCENE_NAME.ToLower ())
            _imgNames = GameConstants.IRVUE_IMG_NAME_ARRAYs.ToList ();
    }

    private void Start ()
    {
        // AssetBundleManager.Instance.CheckDownloadBundleFromRemoteServer(_bundleName);

        _image.sprite = AssetBundleManager.Instance.LoadResourceFromBundle<Sprite> (_imgNames[img_index], _bundleName);
        _image.preserveAspect = true;

    }

}