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