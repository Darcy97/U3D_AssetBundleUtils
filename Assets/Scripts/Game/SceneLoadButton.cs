using System.Collections;
using System.Collections.Generic;
using Libs;
using UnityEngine;
using UnityEngine.UI;

public class SceneLoadButton : MonoBehaviour
{

    public string ToLoadSceneName;

    private void Awake() {
        GetComponent<Button>().onClick.AddListener(OnButtonClick);
    }

    public void OnButtonClick ()
    {
        SceneLoadManager.Instance.LoadScene (ToLoadSceneName);
    }

}