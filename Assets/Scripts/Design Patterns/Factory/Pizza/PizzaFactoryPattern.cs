/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 17:00:19
 * @LastEditTime: 2019-07-31 17:06:39
 */
using DesignPattern;
using Ingredient;
using Libs;
public class PizzaFactoryPattern : PatternMonoBase
{
    private void Awake ()
    {
        ButtonRegister ("Canvas/Start", OnStartButtonClick);
    }

    private void OnStartButtonClick ()
    {
        var dough = new Dough ();
        Log.Print (dough.Name);
    }
}