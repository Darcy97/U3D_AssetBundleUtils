using System.Collections.Generic;
using Ingredient;
using Libs;
namespace FactoryPattern
{
    //* 不同地区生产原料逻辑不同，此处模拟就不再加不同逻辑了
    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough(){
            //* 仅以此标记原料不同
            LogIngredientType();
            return new NYDough();
        }
        public Sauce CreateSouce()
        {
            return new NYSauce();
        }
        public Cheese CreateCheese(){
            return new NYCheese();
        }
        public List<Veggies> CreateVeggies(){
            var veggie = new NYVeggies();
            List<Veggies> result = new List<Veggies>();
            result.Add(veggie);
            return result;
        }
        public Pepperoni CreatePepperoni(){
            return new NYPepperoni();
        }
        public Clam CreateClam(){
            return new NYClam();
        }

        private void LogIngredientType(){
            Log.Print("IngredientType: NY");
        }
    }
}