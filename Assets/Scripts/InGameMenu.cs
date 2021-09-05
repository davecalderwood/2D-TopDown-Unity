using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public static bool inGameMenu = false;
    public static bool inPauseMenu = false;
    public GameObject menuUI, hudDisplay, externalPause;
    public GameObject[] windows;

    private void Start() 
    {
        inGameMenu = false;
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && !inPauseMenu)
        {
            if(inGameMenu)
            {
                Resume();
            }
            else
            {
                Pause(0);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(inPauseMenu)
            {
                ExternalResume();
            }
            else
            {
                ExternalPause();
            }
        }
    }

    void Resume()
    {
        menuUI.SetActive(false);
        hudDisplay.SetActive(true);
        externalPause.SetActive(false);
        Time.timeScale = 1f; // Un-Freeze game when resumed
        inGameMenu = false;
        inPauseMenu = false;
        GameManager.instance.inGameMenuPages = false;

        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }
    }
    void Pause(int windowNumber)
    {
        menuUI.SetActive(true);
        hudDisplay.SetActive(false);
        Time.timeScale = 0f; // Freeze game when paused
        inGameMenu = true;
        GameManager.instance.inGameMenuPages = true; // Freeze character movement when in game menu via game manager

        for(int i = 0; i < windows.Length; i++)
        {
            if(i == windowNumber)
            {
                windows[i].SetActive(!windows[i].activeInHierarchy);
            }
            else
            {
                windows[i].SetActive(false);
            }
        }
    }

    void ExternalPause()
    {
        externalPause.SetActive(true);
        Time.timeScale = 0f;
        inPauseMenu = true;
        GameManager.instance.inGameMenuPages = true;
    }
    public void ExternalResume()
    {
        externalPause.SetActive(false);
        Time.timeScale = 1f;
        inPauseMenu = false;
        GameManager.instance.inGameMenuPages = false;
    }

    public void Settings()
    {
        Debug.Log("Settings");
    }

    public void LoadMenu()
    {
        Debug.Log("Load Menu");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
    }
}
