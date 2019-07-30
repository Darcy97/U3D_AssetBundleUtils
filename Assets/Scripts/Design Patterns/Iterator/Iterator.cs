/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 17:08:44
 * @LastEditTime: 2019-07-30 17:34:15
 */
namespace DesignPattern
{
    public interface Iterator
    {
        bool MoveNext ();
        object GetCurrent ();
        void Next ();
        void Reset ();
    }
}