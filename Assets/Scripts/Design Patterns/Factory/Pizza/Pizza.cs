using System.Collections.Generic;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 16:36:48
 * @LastEditTime: 2019-07-31 17:21:16
 */
using Ingredient;
namespace FactoryPattern
{
    public abstract class Pizza
    {
        private string name;
        private Dough dough;
        private Sauce sauce;
        private List<Veggies> Veggieses;
        private Pepperoni pepperoni;
        private Clam clam;

        public abstract void Prepare ();
    }
}