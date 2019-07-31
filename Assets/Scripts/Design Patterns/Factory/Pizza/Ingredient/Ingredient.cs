/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-31 16:46:24
 * @LastEditTime: 2019-07-31 17:04:01
 */
namespace Ingredient
{
    public abstract class Ingredient
    {
        public string Name { get; set; }
        public Ingredient ()
        {
            Name = this.GetType().Name;
        }
    }
}