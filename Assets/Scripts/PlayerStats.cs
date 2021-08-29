using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public string charName;
    public int playerLevel = 1;
    public int currentEXP;
    public int[] expToNextLevel;
    public int maxLevel = 50;
    public int baseEXP = 1000;
    public int currentHP;
    public int maxHP = 100;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite charImage;
    void Start()
    {
        instance = this;
        
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        // LEAVE AT i = 2 DO NOT CHANGE
        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(250);
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
    public void LevelUpStats()
    {
        currentEXP -= expToNextLevel[playerLevel];
        playerLevel++;

        maxHP = Mathf.FloorToInt(maxHP * 1.05f);
        currentHP = maxHP;
    }
}
