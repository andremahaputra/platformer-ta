using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer.Unity;

public class InGameController : IStartable
{
    private InGameScreen screen;
    private Navigator navigator;
    private SceneContainer scenes;

    public InGameController(InGameScreen screen, Navigator navigator, SceneContainer scenes)
    {
        this.screen = screen;
        this.navigator = navigator;
        this.scenes = scenes;
    }
    
    void IStartable.Start()
    {   
        screen.SetActiveMenu(false);

        screen.menuBtn.onClick.AddListener(() => {
            screen.SetActiveMenu (true);
        });

        screen.returnBtn.onClick.AddListener(() => {
            screen.SetActiveMenu(false);
        });

        screen.backToMainMenuBtn.onClick.AddListener(() => {
            navigator.ToMainMenu();
        });
    }
}