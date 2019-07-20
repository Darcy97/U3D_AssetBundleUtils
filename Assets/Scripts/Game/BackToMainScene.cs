using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Libs;
using UnityEngine.SceneManagement;
using AssetBundleLibs;
public class BackToMainScene : MonoBehaviour
{

    public Button BackButton;

    private string mainSceneName;
    
    private void Awake() {

        AssetBundleManager.Instance.Init(GameConstants.BUNDLE_DOWNLOAD_URL);

        DontDestroyOnLoad(this);
        if(BackButton != null)
            BackButton.onClick.AddListener(OnBackBtnClick);
        mainSceneName = GameConstants.MAIN_SCENE_NAME;
    }
    
    private void OnBackBtnClick(){
        SceneLoadManager.Instance.LoadScene(mainSceneName);
    }

}
