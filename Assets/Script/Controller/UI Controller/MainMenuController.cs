using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

public class MainMenuController : IStartable
{
    private ISceneController navigator;
    private MainMenuScreen screen;

    public MainMenuController(ISceneController navigator, MainMenuScreen screen)
    {
        this.navigator = navigator;
        this.screen = screen;
    }

    public void Start()
    {
        this.Register(screen);
    }

    private void Register(MainMenuScreen screen)
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

    public void OnStartGameClick()
    {
    }

    public async void OnContinueGameClick()
    {
        await navigator.LoadWorldMap().ContinueWith(() =>
        {
            navigator.UnloadMainMenu();
        });
    }
}