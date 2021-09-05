using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills
{
    public enum SkillType
    {
        BurstFire,
    }

    private List<SkillType> unlockedSkillTypeList;

    public PlayerSkills() 
    {
        unlockedSkillTypeList = new List<SkillType>();
    }

    public void UnlockSkill(SkillType skilltype)
    {
        unlockedSkillTypeList.Add(skilltype);
    }

    public bool IsSkillUnlocked(SkillType skilltype)
    {
        return unlockedSkillTypeList.Contains(skilltype);
    }
}
