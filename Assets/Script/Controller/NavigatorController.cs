using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public interface INavigator
{
    public UniTask LoadMainMenu();
    public UniTask UnloadMainMenu();

    public UniTask LoadWorldMap();
    public UniTask UnloadWorldMap();

    public UniTask LoadInGameUI ();
    public UniTask UnloadInGameUI ();


    public UniTask LoadSceneByName(string sceneName, LoadSceneMode mode);
    public UniTask UnloadSceneByName(string sceneName);
}

public class NavigatorController : INavigator
{
    
    private LifetimeScope scope;
    private SceneConfig sceneConfig;

    public NavigatorController(LifetimeScope scope, SceneConfig sceneConfig) { 
        this.scope = scope;
        this.sceneConfig = sceneConfig;
    }

    UniTask INavigator.LoadInGameUI()
    {
        return SceneManager.LoadSceneAsync (sceneConfig.uiInGameScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask INavigator.LoadMainMenu()
    {   
        return SceneManager.LoadSceneAsync(sceneConfig.mainMenuScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask INavigator.LoadSceneByName(string sceneName, LoadSceneMode mode)
    {
        return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask INavigator.LoadWorldMap()
    {
        return SceneManager.LoadSceneAsync (sceneConfig.worldMapScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask INavigator.UnloadInGameUI()
    {
        return SceneManager.UnloadSceneAsync (sceneConfig.uiInGameScene.ScenePath).ToUniTask();
    }

    UniTask INavigator.UnloadMainMenu()
    {
        return SceneManager.UnloadSceneAsync(sceneConfig.mainMenuScene.ScenePath).ToUniTask ();
    }

    UniTask INavigator.UnloadSceneByName(string sceneName)
    {
        return SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects).ToUniTask();
    }

    UniTask INavigator.UnloadWorldMap()
    {
        return SceneManager.UnloadSceneAsync(sceneConfig.worldMapScene.ScenePath).ToUniTask();
    }
}
