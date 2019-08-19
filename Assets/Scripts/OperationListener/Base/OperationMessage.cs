/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 11:39:23
 * @LastEditTime: 2019-08-19 20:23:54
 */
using UnityEngine;

namespace OperationListener
{
    public class OperationMessage
    {
        public string Name { get; private set; }
        public GameObject Sender { get; private set; }

        protected OperationType type; 
        public OperationMessage (string name, GameObject sender)
        {
            Name = name;
            Sender = sender;
        }

        public OperationType GetOperationType(){
            return type;
        }
    }

    public enum OperationType
    {
        Spin,
        Purchase,
        Cost, //游戏金币花费
        Default
    }
}