using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer.Unity;

public class Initialization : IStartable
{
    private Navigator navigator;
    private SceneContainer scenes;

    public Initialization(Navigator navigator, SceneContainer scenes)
    {
        this.navigator = navigator;
        this.scenes = scenes;
    }

    public void Start()
    {
        navigator.Push(scenes.mainMenu);
    }
}
