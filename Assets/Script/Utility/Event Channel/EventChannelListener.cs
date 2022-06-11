using UnityEngine;
using UnityEngine.Events;

public interface IEventListener<T>
{
    public void Raise(T t);
}

public class EventChannelListener<TParameter, TEventChannel, TUnityEvent> : MonoBehaviour, IEventListener<TParameter>
    where TEventChannel : EventChannel<TParameter>
    where TUnityEvent : UnityEvent<TParameter>
{
    public TEventChannel channel;
    public TUnityEvent response;

    void OnEnable() => channel.RegisterListener(this);

    void OnDisable() => channel.UnRegisterListener(this);

    public void Raise(TParameter t) => response.Invoke(t);
}