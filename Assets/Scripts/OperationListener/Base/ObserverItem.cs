/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 17:13:27
 * @LastEditTime: 2019-08-19 20:23:47
 */
using System.Collections.Generic;
namespace OperationListener
{
    public class ObserverItem
    {
        public OperationType OpType { get; set; }
        public IOperationObserver Observer { get; set; }
        public ObserverItem (IOperationObserver observer, OperationType type)
        {
            OpType = type;
            Observer = observer;
        }
    }
}