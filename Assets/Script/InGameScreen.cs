using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : MonoBehaviour
{
    public MainMenuScreen mainMenuScreen;
    public GameObject inGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnMenuButtonPressed () {
        mainMenuScreen.ShowMainMenuPanel ();
    }
}
