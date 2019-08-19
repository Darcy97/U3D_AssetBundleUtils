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