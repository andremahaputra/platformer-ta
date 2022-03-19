using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class Initialization : IStartable
{
    private ISceneController navigator;
    public Initialization(ISceneController navigator)
    {
        this.navigator = navigator;
    }

    public void Start()
    {
        navigator.LoadMainMenu ();
    }
}
