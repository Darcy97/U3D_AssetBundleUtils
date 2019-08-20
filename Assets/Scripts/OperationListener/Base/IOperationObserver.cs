/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 13:57:13
 * @LastEditTime: 2019-08-20 14:28:58
 */

namespace OperationListener
{
    public interface IOperationObserver
    {
       void ObserverUpdate(OperationMessage message);
    }
}