using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 50;
    public int baseEXP = 1000;
    public int currentHP;
    public int maxHP = 100;

    // public int currnetMP;
    // public int maxMP = 30;
    // public int strength;
    // public int defence;
    // public int weaponPower;
    // public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Slider slider;
    private CharacterStats[] playerStats;

    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
            slider.minValue = 0;
            slider.maxValue = expToNextLevel[i];
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
        // slider.value = expToNextLevel / currentEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            slider.value = playerStats[i].currentEXP;
        }
    }

    public void AddExp(int expToAdd)
    {
        currentEXP += expToAdd;

        if(playerLevel < maxLevel)
        {
            if(currentEXP > expToNextLevel[playerLevel])
            {
                LevelUpStats();
            }
        }

        if(playerLevel >= maxLevel)
        {
            currentEXP = 0;
        }
    }

    // On level up add to max health
    public void LevelUpStats()
    {
        currentEXP -= expToNextLevel[playerLevel];
        playerLevel++;

        maxHP = Mathf.FloorToInt(maxHP * 1.05f);
        currentHP = maxHP;
    }

    public void MainStats()
    {
        // playerStats = GameManager.instance.playerStats;

        for(int i = 0; i < playerStats.Length; i++)
        {
            // expToNextLevel[i].text = "" + playerStats[i].currentEXP + "/" + playerStats[i].expToNextLevel[playerStats[i].playerLevel];
            // expSlider[i].maxValue = playerStats[i].expToNextLevel[playerStats[i].playerLevel];
            slider.value = playerStats[i].currentEXP;
            // sliderImage[i].sprite = playerStats[i].characterImage;
        }
    }
}
