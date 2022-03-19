using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootScope : LifetimeScope
{
    [SerializeField]
    private SceneConfig sceneConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<Initialization> (Lifetime.Transient);
        builder.Register<NavigatorController> (Lifetime.Singleton).AsImplementedInterfaces();
        builder.RegisterComponent<SceneConfig>(sceneConfig);
    }
}
