using System.Collections.Generic;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 17:13:22
 * @LastEditTime: 2019-07-30 18:14:26
 */
namespace DesignPattern
{
    public class ConcreteList : IListCollection
    {
        List<int> collection = new List<int> ();

        public ConcreteList (List<int> list)
        {
            collection = list;
        }   

        public Iterator GetIterator ()
        {
            return new ConcreteIterator (this);
        }

        public int Count
        {
            get
            {
                return collection.Count;
            }
        }

        public int GetElement (int index)
        {
            return collection[index];
        }
    }
}