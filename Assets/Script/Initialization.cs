using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class Initialization : IStartable
{
    private INavigator navigator;
    public Initialization(INavigator navigator)
    {
        this.navigator = navigator;
    }

    public void Start()
    {
        navigator.LoadMainMenu ();
    }
}
