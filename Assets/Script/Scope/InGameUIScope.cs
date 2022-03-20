using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class InGameUIScope : LifetimeScope
{
    [SerializeField]
    private InGameScreen inGameScreen;
    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<InGameController> (Lifetime.Scoped);
        builder.RegisterComponent<InGameScreen> (inGameScreen);
    }
}
