/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 11:39:30
 * @LastEditTime: 2019-08-20 14:31:52
 */
using UnityEngine;
namespace OperationListener
{

    public class OperationMessageSpin : OperationMessage
    {
        public string TypeSpin { get; set; }
        public OperationMessageSpin(string name, GameObject sender):base(name, sender)
        {
            type = OperationType.Spin;
            TypeSpin = "Spin";
        }
    }
}