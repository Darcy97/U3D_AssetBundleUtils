/*
 * @Descripttion: 
 * @version: 0.0.0
 * @Author: Darcy
 * @Date: 2019-08-19 17:48:18
 * @LastEditTime: 2019-08-20 14:54:49
 */
using OperationListener;
using UnityEngine;
public class TestOperationListener : MonoBehaviour, IOperationObserver
{

    public void ObserverUpdate (OperationMessage message)
    {
        if (message is OperationMessagePurchase)
            Debug.LogError (message.Name +
                "->" + message.Sender.name +
                "->" + gameObject.name +
                "Type->" +
                (message as OperationMessagePurchase).TypePur);

        if (message is OperationMessageSpin)
            Debug.LogError (message.Name +
                "->" + message.Sender.name +
                "->" + gameObject.name +
                "Type->" +
                (message as OperationMessageSpin).TypeSpin);
    }

    public void Register ()
    {
        PlayerOperationListener.Instance.RegisterObserver (this, OperationType.Purchase, OperationType.Spin);
    }

    public void RegisterSpin ()
    {
        PlayerOperationListener.Instance.RegisterObserver (this, OperationType.Spin);
    }

    public void RegisterPurchase ()
    {
        PlayerOperationListener.Instance.RegisterObserver (this, OperationType.Purchase);
    }

    public void RemoveSpin ()
    {
        PlayerOperationListener.Instance.RemoveObserver (this, OperationType.Spin);
    }

    public void RemovePurchase ()
    {
        PlayerOperationListener.Instance.RemoveObserver (this, OperationType.Purchase);
    }

    public void RemoveAll ()
    {
        PlayerOperationListener.Instance.RemoveObserver (this);
    }

    public void Purchase ()
    {
        var opMessage = new OperationMessagePurchase ("Purchase", gameObject);
        PlayerOperationListener.Instance.SendMessage (opMessage);
        // Messenger.Broadcast<OperationMessage> (PlayerOperationListener.OperationListenerKey, opMessage);
    }

    public void Spin ()
    {
        var opMessage = new OperationMessageSpin ("Spin", gameObject);
        PlayerOperationListener.Instance.SendMessage (opMessage);
        // Messenger.Broadcast<OperationMessage>(PlayerOperationListener.OperationListenerKey, opMessage);
    }

}