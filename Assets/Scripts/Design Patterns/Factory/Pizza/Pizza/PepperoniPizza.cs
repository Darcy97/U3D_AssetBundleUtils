/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:55:55
 * @LastEditTime: 2019-08-07 19:55:55
 */
using Ingredient;
using Libs;
namespace FactoryPattern
{
    public class PepperoniPizza : Pizza
    {
        public PepperoniPizza (IPizzaIngredientFactory ingredientFactory) : base (ingredientFactory) { }

        public override void Prepare ()
        {
            Log.Print (name, "Preparing");
            dough = ingredientFactory.CreateDough ();
            sauce = ingredientFactory.CreateSouce ();
            cheese = ingredientFactory.CreateCheese ();
            clam = ingredientFactory.CreateClam ();
        }
    }
}