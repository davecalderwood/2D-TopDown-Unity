using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool inGameMenu = false;
    public GameObject menuUI;

    private void Start() 
    {
        inGameMenu = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            if(inGameMenu)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    void Resume()
    {
        menuUI.SetActive(false);
        Time.timeScale = 1f; // Un-Freeze game when resumed
        inGameMenu = false;
        GameManager.instance.inGameMenuPages = false;
    }
    void Pause()
    {
        menuUI.SetActive(true);
        Time.timeScale = 0f; // Freeze game when paused
        inGameMenu = true;
        GameManager.instance.inGameMenuPages = true; // Freeze character movement when in game menu via game manager
    }
}
