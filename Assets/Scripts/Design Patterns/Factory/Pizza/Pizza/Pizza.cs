using System.Collections.Generic;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 16:36:48
 * @LastEditTime: 2019-08-07 19:56:37
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