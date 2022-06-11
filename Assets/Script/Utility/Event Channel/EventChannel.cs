using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EventChannel<TParameter> : ScriptableObject
{
    private List<IEventListener<TParameter>> listeners = new List<IEventListener<TParameter>>();

    public void Raise(TParameter param)
    {
        for (int i = 0; i < listeners.Count - 1; i++)
        {
            listeners[i].Raise(param);
        }
    }

    public void RegisterListener(IEventListener<TParameter> listener)
    {
        listeners.Add(listener);
    }

    public void UnRegisterListener(IEventListener<TParameter> listener)
    {
        listeners.Remove(listener);
    }
}
