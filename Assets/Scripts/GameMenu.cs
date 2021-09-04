using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject[] windows;
    public Text[] nameText, hpText, expText, lvlText, skillPointsToSpend;
    public Slider[] expSlider;
    public Image[] charImage;
    public GameObject[] charStatHolder;
    private PlayerStats[] playerStats;

    void Start()
    {
        
    }

    void Update()
    {
        // if(Input.GetButtonDown("Fire2"))
        // {
        //     if(menu.activeInHierarchy)
        //     {
        //         CloseMenu();
        //     }
        //     else 
        //     {
        //         menu.SetActive(true);
        //         UpdateMainStats();
        //         GameManager.instance.gameMenuOpen = true;
        //     }
        // }
    }

    public void UpdateMainStats()
    {

        if(playerStats == null)
        {

        }
        else
        {
            playerStats = GameManager.instance.playerStats;

            for(int i = 0; i < playerStats.Length; i++)
            {
                if(playerStats[i].gameObject.activeInHierarchy)
                {
                    charStatHolder[i].SetActive(true);

                    nameText[i].text = playerStats[i].charName;
                    hpText[i].text = "HP: " + playerStats[i].currentHP + "/" + playerStats[i].maxHP;
                    lvlText[i].text = "LVL: " + playerStats[i].playerLevel;
                    expText[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                    expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
                    expSlider[i].value = playerStats[i].currentEXP;
                    charImage[i].sprite = playerStats[i].charImage;
                    skillPointsToSpend[i].text = "" +  playerStats[i].skillPoints;
                }
                else
                {
                    charStatHolder[i].SetActive(false);
                }
            }
        }
    }

    public void ToggleWindow(int windowNumber)
    {
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

    public void CloseMenu()
    {
        for(int i = 0; i < windows.Length; i++)
        {
            windows[i].SetActive(false);
        }

        menu.SetActive(false);

        GameManager.instance.gameMenuOpen = false;
    }
}
