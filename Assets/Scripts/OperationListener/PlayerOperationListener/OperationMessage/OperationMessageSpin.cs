/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 11:39:30
 * @LastEditTime: 2019-08-19 20:24:04
 */
using UnityEngine;
namespace OperationListener
{

    public class OperationMessageSpin : OperationMessage
    {
        public OperationMessageSpin(string name, GameObject sender):base(name, sender)
        {
            type = OperationType.Spin;
        }
    }
}