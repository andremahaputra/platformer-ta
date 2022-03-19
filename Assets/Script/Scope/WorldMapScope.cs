using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;
using VContainer.Unity;

public class WorldMapScope : LifetimeScope
{

    [SerializeField]
    private WorldMapScreen worldMapScreen;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterComponent<WorldMapScreen> (worldMapScreen);
        builder.RegisterEntryPoint<WorldMapController>(Lifetime.Scoped);
    }
}
