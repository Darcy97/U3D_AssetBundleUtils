using System.Collections.Generic;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 16:36:48
 * @LastEditTime: 2019-07-31 20:22:18
 */
using Ingredient;
using Libs;
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

        public void Bake ()
        {
            Log.Print ("Bake", name);
        }

        public void Cut ()
        {
            Log.Print ("Cut", name);
        }

        public void AA ()
        {
            Log.Print ("", name);
        }
    }
}