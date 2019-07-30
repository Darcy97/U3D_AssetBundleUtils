/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 21:28:45
 * @LastEditTime: 2019-07-30 21:30:59
 */
using Libs;
namespace DesignPattern
{
    public class TomatoScrambledEggs : Food
    {
        public override void PrintFoodName ()
        {
            Log.Print ("Tomato Scrambled Eggs");
        }
    }
}