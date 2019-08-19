/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 17:27:28
 * @LastEditTime: 2019-08-19 20:24:35
 */
namespace OperationListener
{
    public interface IOperationObserverPurchase: IOperationObserver
    {
        void ObserverUpdatePurchase(OperationMessagePurchase message);
    }
}