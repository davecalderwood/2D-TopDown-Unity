using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillTree : MonoBehaviour
{
    private PlayerSkills playerSkills;
    private void Awake() 
    {
        // Find reference to button
        GameObject.Find("BurstFire").GetComponent<Button>();
        Debug.Log("Click");
        playerSkills.UnlockSkill(PlayerSkills.SkillType.BurstFire);
    }

    public void SetPlayerSkills(PlayerSkills playerSkills)
    {
        this.playerSkills = playerSkills;
    }
}
