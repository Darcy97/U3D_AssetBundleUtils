/*
 * @Descripttion: 
 * @version: 0.0.1
 * @Author: Darcy
 * @Date: 2019-07-19 17:16:45
 * @LastEditTime: 2019-07-19 20:23:19
 */
using System;
using System.Reflection;
using UnityEngine;

namespace Libs
{
    /// <summary>
    /// Singleton.
    /// <description>
    /// 此代码引用位置
    /// https://www.codeproject.com/Articles/14026/Generic-Singleton-Pattern-using-Reflection-in-C
    /// http://www.cnblogs.com/zhili/p/SingletonPatterm.html
    ///       
    /// 所有单例在初始化时，都需要对数据成员进行重置处理,因为可能单例的配置数据会进行重置更新处理
    /// !使用Singleton生成单例时一定注意使用的类包含私有无参构造方法
    /// </description>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public static class Singleton<T> where T : class
    {
        private static volatile T _instance;

        /// <summary>
        /// *用于确定线程是否同步的标识
        /// </summary>
        /// <returns></returns>
        private static readonly object _locker = new object ();

        /// <summary>
        /// 当第一个线程运行到这里时，此时会对locker对象 "加锁"，
        /// 当第二个线程运行该方法时，首先检测到locker对象为"加锁"状态，该线程就会挂起等待第一个线程解锁
        /// lock语句运行完之后（即线程运行完之后）会对该对象"解锁"
        /// 双重锁定只需要一句判断就可以了
        /// </summary>
        public static T Instance
        {

            get
            {
                if (_instance == null)
                {
                    lock (_locker)
                    {
                        if (_instance == null)
                        {
                            ConstructorInfo constructorInfo = null;

                            try
                            {
                                // Binding flags exclude public constructors.
                                constructorInfo = typeof (T).GetConstructor (BindingFlags.Instance |
                                    BindingFlags.NonPublic, null, new Type[0], null);
                            }
                            catch (Exception exception)
                            {
                                Log.Error ("GetConstructor", exception.Message);
                            }

                            // !Also exclude internal constructors.
                            if (constructorInfo == null || constructorInfo.IsAssembly)
                                Log.Error ("A private or protected constructor is missing", typeof (T).Name);

                            _instance = (T) constructorInfo.Invoke (null);
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// 定义私有构造函数 使外界无法创建该类实例
        /// </summary>
        static Singleton () { }

    }
}