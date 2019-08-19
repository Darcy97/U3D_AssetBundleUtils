/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 11:40:34
 * @LastEditTime: 2019-08-19 20:24:02
 */
using UnityEngine;
namespace OperationListener
{

    public class OperationMessagePurchase : OperationMessage
    {
        public OperationMessagePurchase(string name, GameObject sender):base(name, sender)
        {
            type = OperationType.Purchase;
        }
    }
}