using System;
using DesignPattern;
using Libs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class FactoryPattern : PatternMonoBase
{
    private void Awake ()
    {
        ButtonRegister ("Canvas/TButton", OnTButtonClick);
        ButtonRegister ("Canvas/SButton", OnSButtonClick);
        ButtonRegister ("Canvas/DButton", OnDButtonClick);
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