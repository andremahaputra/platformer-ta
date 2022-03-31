using UnityEngine;
using VContainer.Unity;

public class InGameController : IStartable
{
    private InGameScreen screen;

    public InGameController(InGameScreen screen)
    {
        this.screen = screen;
    }
    
    void IStartable.Start()
    {
        screen.menuBtn.onClick.AddListener(() => {
            Debug.Log("Open menu");
        });

        screen.returnBtn.onClick.AddListener(() => {
            screen.menuPanel.SetActive(false);
        });
    }
}