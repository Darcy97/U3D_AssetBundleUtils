/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 17:27:39
 * @LastEditTime: 2019-08-19 20:29:26
 */


using System.Runtime.CompilerServices;
namespace OperationListener
{
    public interface IOperationObserverSpin: IOperationObserver
    {
        void ObserverUpdateSpin(OperationMessageSpin message);
    }
}