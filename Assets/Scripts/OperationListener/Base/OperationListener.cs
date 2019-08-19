using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;
namespace OperationListener
{
    public abstract class OperationListener
    {

        #region Internal Var

        protected List<ObserverItem> observerItems = new List<ObserverItem> ();

        #endregion

        #region Public Method

        /// <summary>
        /// 注册监听事件类型
        /// </summary>
        public virtual void Init () { }

        public void SendMessage (OperationMessage message)
        {
            OnReceiveOperationMessage (message);
        }

        /// <summary>
        /// 不传type时对 observer进行检查，实现了几种接口就监听几种
        /// 传入type时 只监听对应接口
        /// </summary>
        /// <param name="observer"></param>
        /// <param name="type"></param>
        public void RegisterObserver (IOperationObserver observer, OperationType type = OperationType.Default)
        {

            if (observer == null)
                return;

            if (!type.Equals (OperationType.Default))
            {
                var observerItem = new ObserverItem (observer, type);
                if (!observerItems.Contains (observerItem))
                    observerItems.Add (observerItem);
                return;
            }
            else
            {
                var types = ParseOperationTypeOfObserver (observer);
                if (types == null)
                    return;

                foreach (var item in types)
                {
                    var observerItem = new ObserverItem (observer, item);
                    if (!observerItems.Contains (observerItem))
                        observerItems.Add (observerItem);
                }
            }
        }

        public void RemoveObserver (IOperationObserver observer, OperationType type = OperationType.Default)
        {
            List<ObserverItem> obItems = new List<ObserverItem> ();
            foreach (var item in observerItems)
            {
                if (observer.Equals (item.Observer))
                {
                    obItems.Add (item);
                }
            }

            if (obItems != null)
            {
                foreach (var item in obItems)
                {
                    if (type == OperationType.Default || item.OpType.Equals (type))
                    {
                        observerItems.Remove (item);
                    }
                }
            }
        }

        public void RemoveAllObservers ()
        {
            observerItems.Clear ();
        }

        #endregion

        #region Internal Method

        /// <summary>
        /// 解析分类message 子类重写
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        protected virtual void OnReceiveOperationMessage (OperationMessage operationMessage)
        {

            NotifyObservers (operationMessage);
        }

        protected void NotifyObservers (OperationMessage message)
        {
            if (observerItems == null)
                return;

            foreach (var obItem in observerItems)
            {
                if (message.GetOperationType ().Equals (obItem.OpType))
                {
                    NotifyObserver (message, obItem.Observer, obItem.OpType);
                }

            }
        }

        protected abstract List<OperationType> ParseOperationTypeOfObserver (IOperationObserver observer);
        protected abstract void NotifyObserver (OperationMessage message, IOperationObserver observer, OperationType opType);

        #endregion

    }

}