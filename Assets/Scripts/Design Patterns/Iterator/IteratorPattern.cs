/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-07-30 16:58:52
 * @LastEditTime: 2019-07-30 21:52:41
 */
using System.Collections;
using System.Collections.Generic;
using Libs;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 迭代器是针对集合对象而生的,对于集合对象而言
/// 必然涉及到集合元素的添加删除操作
/// 同时也肯定支持遍历集合元素的操作
/// 我们此时可以把遍历操作也放在集合对象中
/// 但这样的话，集合对象就承担太多的责任了
/// 面向对象设计原则中有一条是单一职责原则
/// 所以我们要尽可能地分离这些职责
/// 用不同的类去承担不同的职责
/// 迭代器模式就是用迭代器类来承担遍历集合元素的职责。
/// https://www.cnblogs.com/zhili/p/IteratorPattern.html
/// </summary>

namespace DesignPattern
{

    public class IteratorPattern : MonoBehaviour
    {

        private void Start ()
        {
            transform.Find ("Canvas/Start").GetComponent<Button> ().onClick.AddListener (OnStartButtonClick);
        }

        public void OnStartButtonClick ()
        {
            Log.Print ("start");
            PatternStart ();
        }

        private void PatternStart ()
        {
            Iterator iterator;
            List<int> _list = new List<int> ();
            _list.Add (2);
            _list.Add (3);
            _list.Add (5);
            IListCollection list = new ConcreteList (_list);
            iterator = list.GetIterator ();

            while (iterator.MoveNext ())
            {
                int i = (int) iterator.GetCurrent ();
                Log.Print (i.ToString ());
                iterator.Next ();
            }
        }
    }
}