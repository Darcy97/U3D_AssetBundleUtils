using System;
using UnityEngine;
/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 17:16:46
 * @LastEditTime: 2019-07-30 17:53:20
 */
namespace DesignPattern
{
    public class ConcreteIterator : Iterator
    {
        private ConcreteList _list;
        private int _index;

        public ConcreteIterator (ConcreteList list)
        {
            _list = list;
            _index = 0;
        }

        public bool MoveNext ()
        {
            if (_index < _list.Count)
            {
                return true;
            }
            return false;
        }

        public object GetCurrent ()
        {
            return _list.GetElement (_index);
        }

        public void Reset ()
        {
            _index = 0;
        }

        public void Next ()
        {
            if (_index < _list.Count)
                _index++;
        }
    }
}