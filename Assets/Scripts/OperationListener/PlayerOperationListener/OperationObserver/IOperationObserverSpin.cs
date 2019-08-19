using System.Runtime.CompilerServices;
namespace OperationListener
{
    public interface IOperationObserverSpin: IOperationObserver
    {
        void ObserverUpdateSpin(OperationMessageSpin message);
    }
}