using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats instance;
    public int playerLevel = 1;
    public int currentEXP, currentHP, skillPoints;
    public int[] expToNextLevel;
    public int maxLevel = 50;
    public int baseEXP = 1000;
    public int maxHP = 100;
    public string equippedWeapon, equippedArmor, charName;
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

        // Temporary
        currentHP = maxHP;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            AddExp(250);
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(15);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            Healing(25);
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
        // Add level
        currentEXP -= expToNextLevel[playerLevel];
        playerLevel++;

        // Add max HP and reset HP to full
        maxHP = Mathf.FloorToInt(maxHP * 1.05f);
        currentHP = maxHP;

        // Add Skill point
        if(playerLevel <= 3)
        {
            skillPoints = 0;
        }
        else
        {
            skillPoints++;
        }
        // skillPoints++;
    }

    public void TakeDamage(int damageTaken)
    {
        currentHP -= damageTaken;

        if(currentHP <= 0)
        {
            currentHP = 0;

            // DeathSequence();
        }
    }
    public void Healing(int healPoints)
    {
        currentHP += healPoints;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    }
}
