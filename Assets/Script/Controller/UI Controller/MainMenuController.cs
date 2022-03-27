using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

public class MainMenuController : IStartable
{
    private Navigator navigator;
    private MainMenuScreen screen;
    private SceneContainer scenes;

    public MainMenuController(Navigator navigator, MainMenuScreen screen, SceneContainer scenes)
    {
        this.navigator = navigator;
        this.screen = screen;
        this.scenes = scenes;
    }

    public void Start()
    {
        screen.startGameBtn.onClick.AddListener(() =>
       {
           OnStartGameClick();
       });

        screen.continueGameBtn.onClick.AddListener(() =>
        {
            OnContinueGameClick();
        });
    }
    public async void OnStartGameClick()
    {
        await navigator.Push(scenes.worldMap).ContinueWith(() =>
        {
            navigator.Pop(scenes.mainMenu);
        });
    }

    public async void OnContinueGameClick()
    {
        await navigator.Push(scenes.worldMap).ContinueWith(() =>
        {
            navigator.Pop(scenes.mainMenu);
        });
    }
}