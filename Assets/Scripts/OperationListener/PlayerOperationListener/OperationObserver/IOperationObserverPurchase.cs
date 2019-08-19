namespace OperationListener
{
    public interface IOperationObserverPurchase: IOperationObserver
    {
        void ObserverUpdatePurchase(OperationMessagePurchase message);
    }
}