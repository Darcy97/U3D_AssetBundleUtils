using DesignPattern;
using UnityEngine;
using UnityEngine.UI;
public class FactoryPattern : MonoBehaviour
{
    private void Awake ()
    {
        //TODO 为空检测
        transform.Find ("Canvas/TButton").GetComponent<Button> ().onClick.AddListener (OnTButtonClick);
        transform.Find ("Canvas/SButton").GetComponent<Button> ().onClick.AddListener (OnSButtonClick);
        transform.Find ("Canvas/DButton").GetComponent<Button> ().onClick.AddListener (OnDButtonClick);
    }

    private Button GetButton ()
    {
        //todo
        return null;
    }

    private void OnTButtonClick ()
    {
        CookFood (FoodType.TomatoScrambledEggs);
    }

    private void OnSButtonClick ()
    {
        CookFood (FoodType.ShreddedPorkWithPotatoe);
    }

    private void OnDButtonClick ()
    {
        CookFood (FoodType.Default);
    }

    private void CookFood (FoodType type)
    {
        Food food = FoodFactory.CreateFood (type);
        if (food != null)
            food.PrintFoodName ();
    }
}