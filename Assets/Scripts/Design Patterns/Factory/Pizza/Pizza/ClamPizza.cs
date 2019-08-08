/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:36:42
 * @LastEditTime: 2019-08-07 19:54:29
 */
using Ingredient;
using Libs;
namespace FactoryPattern
{
    public class ClamPizza : Pizza
    {
        public ClamPizza (IPizzaIngredientFactory ingredientFactory) : base (ingredientFactory) { }

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