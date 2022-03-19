using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

public interface ISceneController
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

public class SceneController : ISceneController
{
    
    private LifetimeScope scope;
    private SceneConfig sceneConfig;

    public SceneController(LifetimeScope scope, SceneConfig sceneConfig) { 
        this.scope = scope;
        this.sceneConfig = sceneConfig;
    }

    UniTask ISceneController.LoadInGameUI()
    {
        return SceneManager.LoadSceneAsync (sceneConfig.uiInGameScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask ISceneController.LoadMainMenu()
    {   
        return SceneManager.LoadSceneAsync(sceneConfig.mainMenuScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask ISceneController.LoadSceneByName(string sceneName, LoadSceneMode mode)
    {
        return SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask ISceneController.LoadWorldMap()
    {
        return SceneManager.LoadSceneAsync (sceneConfig.worldMapScene.ScenePath, LoadSceneMode.Additive).ToUniTask();
    }

    UniTask ISceneController.UnloadInGameUI()
    {
        return SceneManager.UnloadSceneAsync (sceneConfig.uiInGameScene.ScenePath).ToUniTask();
    }

    UniTask ISceneController.UnloadMainMenu()
    {
        return SceneManager.UnloadSceneAsync(sceneConfig.mainMenuScene.ScenePath).ToUniTask ();
    }

    UniTask ISceneController.UnloadSceneByName(string sceneName)
    {
        return SceneManager.UnloadSceneAsync(sceneName, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects).ToUniTask();
    }

    UniTask ISceneController.UnloadWorldMap()
    {
        return SceneManager.UnloadSceneAsync(sceneConfig.worldMapScene.ScenePath).ToUniTask();
    }
}
