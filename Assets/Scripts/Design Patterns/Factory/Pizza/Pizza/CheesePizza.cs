/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:18:06
 * @LastEditTime: 2019-08-07 19:54:06
 */
using Ingredient;
using Libs;
namespace FactoryPattern
{
    public class CheesePizza : Pizza
    {

        public CheesePizza (IPizzaIngredientFactory ingredientFactory) : base (ingredientFactory) { }
        public override void Prepare ()
        {
            Log.Print (name, "Preparing");
            dough = ingredientFactory.CreateDough ();
            sauce = ingredientFactory.CreateSouce ();
            cheese = ingredientFactory.CreateCheese ();
        }
    }
}