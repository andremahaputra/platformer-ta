using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public interface INavigator
{
    public void LoadMainMenu();
    public void UnloadMainMenu();

    public void LoadWorldMap();
    public void UnloadWorldMap();

    public void LoadSceneByName(string sceneName, LoadSceneMode mode);
    public void UnloadSceneByName(string sceneName);
}

public class NavigatorController : INavigator
{
    
    private LifetimeScope scope;
    private SceneConfig sceneConfig;

    public NavigatorController(LifetimeScope scope, SceneConfig sceneConfig) { 
        this.scope = scope;
        this.sceneConfig = sceneConfig;
    }

    void INavigator.LoadMainMenu()
    {   
        SceneManager.LoadSceneAsync(sceneConfig.mainMenuScene.ScenePath, LoadSceneMode.Additive);
    }

    void INavigator.LoadSceneByName(string sceneName, LoadSceneMode mode)
    {
        SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
    }

    void INavigator.LoadWorldMap()
    {
        SceneManager.LoadSceneAsync (sceneConfig.worldMapScene.ScenePath, LoadSceneMode.Additive);
    }

    void INavigator.UnloadMainMenu()
    {
        SceneManager.UnloadSceneAsync(sceneConfig.mainMenuScene.ScenePath);
    }

    void INavigator.UnloadSceneByName(string sceneName)
    {
        SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    void INavigator.UnloadWorldMap()
    {
        SceneManager.UnloadSceneAsync(sceneConfig.worldMapScene.ScenePath);
    }
}
