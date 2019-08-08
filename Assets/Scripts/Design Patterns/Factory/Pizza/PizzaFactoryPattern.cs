/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 17:00:19
 * @LastEditTime: 2019-08-07 20:36:58
 */
using DesignPattern;
using Ingredient;
using Libs;
using FactoryPattern;
public class PizzaFactoryPattern : PatternMonoBase
{
    private void Awake ()
    {
        ButtonRegister ("Canvas/Start", OnStartButtonClick);
    }

    private void OnStartButtonClick ()
    {
        var factory = new NYPizzaStore();
        var pizza = factory.OrderPizza(PizzaType.Cheese);
        Log.Print(pizza.GetName());
        
    }
}