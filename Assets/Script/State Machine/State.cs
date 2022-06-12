using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    public List<Transition> transitions = new List<Transition>();

    public abstract void OnEnter();

    public virtual void OnUpdate()
    {
        Debug.Log("Current state >>> " + this);
    }

    public abstract void OnExit();
}
