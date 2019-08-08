/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 17:00:19
 * @LastEditTime: 2019-08-08 12:05:33
 */

 /// <summary>
 /// 所有的工厂都是用来封装对象的创建
 /// 简单工厂，虽然不是真正的设计模式，当仍不失为一种解藕的办法
 /// 工厂方法使用继承： 把对象的创建委托给子类，子类实现工厂方法来创建对象
 /// 抽象工厂使用对象组合：对象的创建被实现在工厂接口所暴露出来的方法中
 /// 工程方法允许类将实例化延迟到子类执行
 /// </summary>
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