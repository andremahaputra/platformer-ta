using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScreen : MonoBehaviour
{
    public GameObject mainMenuPanel;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void onStartButtonPressed()
    {
        HideMainMenuPanel();
    }

    public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
    }

    public void HideMainMenuPanel()
    {
        mainMenuPanel.SetActive(false);
    }

}
