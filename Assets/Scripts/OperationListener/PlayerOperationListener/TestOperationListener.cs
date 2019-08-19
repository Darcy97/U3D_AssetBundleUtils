using OperationListener;
using UnityEngine;
public class TestOperationListener : MonoBehaviour, IOperationObserverPurchase, IOperationObserverSpin
{

    private void Start() {
        // PlayerOperationListener.Instance.Init();
    }

    public void ObserverUpdatePurchase (OperationMessagePurchase message)
    {
        Debug.LogError(message.Name + "->" + message.Sender.name + "->" + gameObject.name);
    }

    public void ObserverUpdateSpin (OperationMessageSpin message)
    {
        Debug.LogError(message.Name + "->" + message.Sender.name + "->" + gameObject.name);
    }

    public void Register(){
        PlayerOperationListener.Instance.RegisterObserver(this);
    }

    public void RegisterSpin(){
        PlayerOperationListener.Instance.RegisterObserver(this, OperationType.Spin);
    }

    public void RegisterPurchase(){
        PlayerOperationListener.Instance.RegisterObserver(this, OperationType.Purchase);
    }

    public void RemoveSpin(){
        PlayerOperationListener.Instance.RemoveObserver(this, OperationType.Spin);
    }

    public void RemovePurchase(){
        PlayerOperationListener.Instance.RemoveObserver(this, OperationType.Purchase);
    }

    public void RemoveAll(){
        PlayerOperationListener.Instance.RemoveObserver(this);
    }

    public void Purchase ()
    {
        var opMessage = new OperationMessagePurchase ("Purchase", gameObject);
        PlayerOperationListener.Instance.SendMessage(opMessage);
        // Messenger.Broadcast<OperationMessage> (PlayerOperationListener.OperationListenerKey, opMessage);
    }

    public void Spin(){
        var opMessage = new OperationMessageSpin("Spin", gameObject);
        PlayerOperationListener.Instance.SendMessage(opMessage);
        // Messenger.Broadcast<OperationMessage>(PlayerOperationListener.OperationListenerKey, opMessage);
    }

}