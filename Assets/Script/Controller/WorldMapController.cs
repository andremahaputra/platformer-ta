using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class WorldMapController : IStartable
{
    private INavigator navigator;
    private WorldMapScreen screen;
    public WorldMapController(INavigator navigator,  WorldMapScreen screen)
    {
        this.navigator = navigator;
        this.screen = screen;
    }

    public void Start()
    {
        this.Register (screen);
    }

    public void Register(WorldMapScreen screen)
    {
        screen.stageTiles.ForEach((tile) =>
        {
            tile.btn.onClick.AddListener(() =>
            {
                SelectStage(tile.stageData);
            });
        });
    }

    public void SelectStage(StageData data)
    {
        navigator.LoadSceneByName (data.scene.ScenePath, LoadSceneMode.Single);
        Debug.Log("Load scene: " + data.scene.ScenePath);
    }
}