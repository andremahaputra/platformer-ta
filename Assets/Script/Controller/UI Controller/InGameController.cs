using UnityEngine;
using VContainer.Unity;

public class InGameController : IStartable, ITickable
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
    }

    void ITickable.Tick()
    {
        UpdateHealthText ();
    }

    private void UpdateHealthText () {
        screen.healthTxt.text = screen.status.health.ToString();
    }
}