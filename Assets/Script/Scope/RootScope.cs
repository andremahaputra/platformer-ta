using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class RootScope : LifetimeScope
{
    [SerializeField]
    private SceneContainer sceneConfig;
    
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<Initialization> (Lifetime.Transient);
        builder.Register<Navigator> (Lifetime.Singleton);
        builder.RegisterComponent<SceneContainer>(sceneConfig);
    }
}
