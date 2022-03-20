using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class WorldMapController : IStartable
{
    private ISceneController navigator;
    private WorldMapScreen screen;
    public WorldMapController(ISceneController navigator,  WorldMapScreen screen)
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

    public async void SelectStage(StageData data)
    {   
        await navigator.LoadInGameUI ().ContinueWith (async () => {
            await navigator.LoadSceneByName (data.scene.ScenePath, LoadSceneMode.Single);
        });
        await navigator.UnloadWorldMap ();
    }
}