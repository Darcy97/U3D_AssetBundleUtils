/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 19:40:32
 * @LastEditTime: 2019-08-08 11:07:26
 */
using Ingredient;
namespace FactoryPattern
{
    public abstract class PizzaStore
    {
        public Pizza OrderPizza (PizzaType type)
        {
            Pizza pizza = CreatePizza (type);

            pizza.Prepare ();
            pizza.Bake ();
            pizza.Cut ();
            pizza.Box ();

            return pizza;
        }

        protected abstract Pizza CreatePizza (PizzaType type);

    }
}