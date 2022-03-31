using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class WorldMapController : IStartable
{
    private Navigator navigator;
    private WorldMapScreen screen;
    private SceneContainer scenes;

    public WorldMapController(Navigator navigator, WorldMapScreen screen, SceneContainer scenes)
    {
        this.navigator = navigator;
        this.screen = screen;
        this.scenes = scenes;
    }

    public void Start()
    {
        screen.stageTiles.ForEach((tile) =>
        {
            tile.btn.onClick.AddListener(() =>
            {
                SelectStage(tile.stageData);
            });
        });

        screen.backBtn.onClick.AddListener(() =>
        {
            navigator.ToMainMenu();
        });
    }

    public async void SelectStage(StageData data)
    {
        await navigator.Push(scenes.ui_inGame).ContinueWith(async () =>
        {
            await navigator.Push(data.scene, LoadSceneMode.Single);
        });

        await navigator.Pop(scenes.worldMap);
    }
}