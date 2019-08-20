/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 11:40:34
 * @LastEditTime: 2019-08-20 14:32:12
 */
using UnityEngine;
namespace OperationListener
{

    public class OperationMessagePurchase : OperationMessage
    {
        public string TypePur { set; get; }
        public OperationMessagePurchase (string name, GameObject sender) : base (name, sender)
        {
            type = OperationType.Purchase;
            TypePur = "Pur";
        }
    }
}