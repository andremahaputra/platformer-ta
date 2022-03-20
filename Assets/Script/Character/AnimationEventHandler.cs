using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    public delegate void AnimationEventDelegate(string eventName);

    public event AnimationEventDelegate OnAnimationEvent;

    public void InvokeEvent(string eventName)
    {
        OnAnimationEvent?.Invoke(eventName);
    }

}
