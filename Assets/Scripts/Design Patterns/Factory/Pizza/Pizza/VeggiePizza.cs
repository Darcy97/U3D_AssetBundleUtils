/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:54:49
 * @LastEditTime: 2019-08-07 19:56:57
 */
using Ingredient;
using Libs;
namespace FactoryPattern
{
    public class VeggiePizza : Pizza
    {
        public VeggiePizza (IPizzaIngredientFactory ingredientFactory) : base (ingredientFactory) { }
        public override void Prepare ()
        {
            Log.Print (name, "Preparing");
            dough = ingredientFactory.CreateDough ();
            sauce = ingredientFactory.CreateSouce ();
            cheese = ingredientFactory.CreateCheese ();
        }
    }
}