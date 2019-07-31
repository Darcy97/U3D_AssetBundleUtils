/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 21:34:35
 * @LastEditTime: 2019-07-30 22:06:45
 */
using Libs;
namespace DesignPattern
{
    public class FoodFactory
    {
        /// <summary>
        /// return food
        /// ! can be null
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Food CreateFood (FoodType type)
        {
            Food food = null;
            switch (type)
            {
                case FoodType.TomatoScrambledEggs:
                    food = new TomatoScrambledEggs ();
                    break;
                case FoodType.ShreddedPorkWithPotatoe:
                    food = new ShreddedPorkWithPotatoe ();
                    break;
                default:
                    Log.Error ("FoodFactory not contain this case", type.ToString ());
                    break;
            }
            return food;
        }
    }

    public enum FoodType
    {
        ShreddedPorkWithPotatoe,
        TomatoScrambledEggs,
        Default
    }
}