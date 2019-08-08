/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-07 19:21:26
 * @LastEditTime: 2019-08-07 19:32:05
 */
using System.Collections.Generic;
namespace Ingredient
{
    public interface IPizzaIngredientFactory {
        Dough CreateDough();
        Sauce CreateSouce();
        Cheese CreateCheese();
        List<Veggies> CreateVeggies();
        Pepperoni CreatePepperoni();
        Clam CreateClam();
    }
}