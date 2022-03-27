using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public class Navigator
{
    private LifetimeScope scope;
    private SceneContainer config;

    public Navigator(LifetimeScope scope, SceneContainer sceneConfig)
    {
        this.scope = scope;
        this.config = sceneConfig;
    }

    public UniTask Push(SceneReference scene, LoadSceneMode mode = LoadSceneMode.Single)
    {
        return SceneManager.LoadSceneAsync(scene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    public UniTask PushNamed(string name, LoadSceneMode mode = LoadSceneMode.Single) {
        return SceneManager.LoadSceneAsync (name, mode).ToUniTask ();
    }

    public UniTask Pop(SceneReference scene, UnloadSceneOptions option = UnloadSceneOptions.None)
    {
        return SceneManager.UnloadSceneAsync(scene.ScenePath, option).ToUniTask();
    }
}
