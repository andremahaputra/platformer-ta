using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class Navigator
{
    private LifetimeScope scope;
    private SceneContainer scenes;

    public Navigator(LifetimeScope scope, SceneContainer scenes)
    {
        this.scope = scope;
        this.scenes = scenes;
    }

    public UniTask Push(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        return SceneManager.LoadSceneAsync(scene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    public UniTask PushNamed(string name, LoadSceneMode mode = LoadSceneMode.Single)
    {
        return SceneManager.LoadSceneAsync(name, mode).ToUniTask();
    }

    public UniTask Pop(SceneReference scene, UnloadSceneOptions option = UnloadSceneOptions.None)
    {
        return SceneManager.UnloadSceneAsync(scene.ScenePath, option).ToUniTask();
    }

    public UniTask ToProlog()
    {
        return SceneManager.LoadSceneAsync(scenes.prolog).ToUniTask();
    }

    public UniTask ToMainMenu()
    {
        return SceneManager.LoadSceneAsync(scenes.mainMenu).ToUniTask();
    }

    public UniTask ToWorldMap()
    {
        return SceneManager.LoadSceneAsync(scenes.worldMap, LoadSceneMode.Single).ToUniTask();
    }

    public UniTask ToStage(StageData stage)
    {
        return Push(scenes.ui_controller).ContinueWith(() =>
        {
            Push(stage.scene, LoadSceneMode.Single);
        }).ContinueWith(() =>
        {
            Pop(scenes.worldMap);
        });
    }
}
