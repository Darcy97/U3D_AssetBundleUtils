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