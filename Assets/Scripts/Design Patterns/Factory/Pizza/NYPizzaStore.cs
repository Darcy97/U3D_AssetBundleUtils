/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:58:10
 * @LastEditTime: 2019-08-08 11:01:55
 */
using Ingredient;
namespace FactoryPattern
{
    public class NYPizzaStore : PizzaStore
    {
        string style = "New York Style";
        protected override Pizza CreatePizza (PizzaType type)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NYPizzaIngredientFactory ();

            switch (type)
            {
                case PizzaType.Cheese:
                    pizza = new CheesePizza (ingredientFactory);
                    pizza.SetName(style + "Cheese Pizza");
                    break;
                case PizzaType.Clam:
                    pizza = new ClamPizza (ingredientFactory);
                    pizza.SetName(style + "Clam Pizza");
                    break;
                case PizzaType.Veggie:
                    pizza = new VeggiePizza (ingredientFactory);
                    pizza.SetName(style + "Veggie Pizza");
                    break;
                case PizzaType.Pepperoni:
                    pizza = new PepperoniPizza (ingredientFactory);
                    pizza.SetName(style + "Pepperoni Pizza");
                    break;
            }

            return pizza;
        }
    }
}