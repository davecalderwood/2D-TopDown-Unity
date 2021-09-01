using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameViewOverlay : MonoBehaviour
{
    public static GameViewOverlay instance;
    public Text hpText, lvlText, expText;
    public Slider expSlider, hpSlider;
    private PlayerStats playerOverlay;
    public GameObject charStatHolder;

    void Start()
    {
        instance = this;

        UpdateMainStats();
    }

    void FixedUpdate()
    {
        UpdateMainStats();
    }

    public void UpdateMainStats()
    {
        playerOverlay = GameManager.instance.playerOverlay;

        if(playerOverlay == null)
        {
            
        }
        else
        {
            // EXP Bar
            expText.text = "" + playerOverlay.currentEXP + "/" + playerOverlay.expToNextLevel[playerOverlay.playerLevel];
            expSlider.maxValue = playerOverlay.expToNextLevel[playerOverlay.playerLevel];
            expSlider.value = playerOverlay.currentEXP;

            // HP Bar
            hpText.text = "" + playerOverlay.currentHP + "/" + playerOverlay.maxHP;
            hpSlider.maxValue = playerOverlay.maxHP;
            hpSlider.value = playerOverlay.currentHP;

            lvlText.text = "" + playerOverlay.playerLevel;

            // hpText.text = "HP: " + playerOverlay.currentHP + "/" + playerOverlay.maxHP;
        }
    }
}
