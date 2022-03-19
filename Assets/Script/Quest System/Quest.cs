using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest: ScriptableObject
{
    public string id;
    public string description;

    public delegate void ActivateDelegate(Quest quest);
    public delegate void ResolveDelegate(Quest quest);

    public abstract event ActivateDelegate OnActivate;
    public abstract event ResolveDelegate OnResolve;

    public abstract void Activate();
    public abstract void Resolve();

}
