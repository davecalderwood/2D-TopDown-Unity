using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int strength;
    public int defence;
    public int weaponPower;
    public int armorPower;
    public string equippedWeapon;
    public string equippedArmor;
    public Sprite characterImage;

    void Start()
    {
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for(int i = 2; i < expToNextLevel.Length; i++)
        {
            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f);
        }
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
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
}
