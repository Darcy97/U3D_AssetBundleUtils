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