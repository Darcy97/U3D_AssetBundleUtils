using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Libs;
using UnityEngine.SceneManagement;
public class BackToMainScene : MonoBehaviour
{

    public Button BackButton;

    private string mainSceneName;
    
    private void Awake() {
        DontDestroyOnLoad(this);
        if(BackButton != null)
            BackButton.onClick.AddListener(OnBackBtnClick);
        mainSceneName = SceneManager.GetActiveScene().name;
    }
    
    private void OnBackBtnClick(){
        SceneLoadManager.Instance.LoadScene(mainSceneName);
    }

}
