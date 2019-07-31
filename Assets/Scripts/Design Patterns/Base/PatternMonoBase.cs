using System;
using DesignPattern;
using Libs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
namespace DesignPattern
{
    public class PatternMonoBase : MonoBehaviour
    {
        protected void ButtonRegister (string path, UnityAction onClick)
        {
            if (onClick == null)
                return;

            var go = transform.Find (path);
            if (go == null)
            {
                Log.Error ("Button is null", path);
                return;
            }

            var button = go.GetComponent<Button> ();
            if (button == null)
            {
                Log.Error ("There is no button script added", path);
                return;
            }

            button.onClick.AddListener (onClick);
        }
    }
}