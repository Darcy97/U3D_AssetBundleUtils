using System.Collections.Generic;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 16:36:48
 * @LastEditTime: 2019-08-08 12:05:32
 */
using Ingredient;
using Libs;
namespace FactoryPattern
{
    public abstract class Pizza
    {
        protected string name;
        protected Dough dough;
        protected Sauce sauce;
        protected List<Veggies> Veggieses;
        protected Cheese cheese;
        protected Pepperoni pepperoni;
        protected Clam clam;
        protected IPizzaIngredientFactory ingredientFactory;
        
        /// <summary>
        /// 由于目前每一种pizza构造方法的不同之处在于原料工厂不同
        /// 且c#允许抽象类存在构造方法
        /// 所以这里在抽象类中构建构造方法
        /// 子类继承父类时只需继承构造方法传入原料工厂引用即可
        /// </summary>
        /// <param name="ingredientFactory"></param>
        protected Pizza(IPizzaIngredientFactory ingredientFactory){
            this.ingredientFactory = ingredientFactory;
        }

        public abstract void Prepare ();

        public void Bake ()
        {
            Log.Print ("Bake", name);
        }

        public void Cut ()
        {
            Log.Print ("Cut", name);
        }

        public void Box ()
        {
            Log.Print ("Box", name);
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public string GetName(){
            return name;
        }
    }
}