using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class MainMenuScope : LifetimeScope
{
    [SerializeField]
    private MainMenuScreen mainMenuScreen;
    protected override void Configure(IContainerBuilder builder)
    { 
        builder.RegisterComponent<MainMenuScreen> (mainMenuScreen);
        builder.RegisterEntryPoint<MainMenuController> (Lifetime.Scoped);
    }
}
