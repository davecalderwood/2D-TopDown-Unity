using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeBuild : MonoBehaviour
{
    public static SkillTreeBuild skillTree;
    private void Awake() => skillTree = this;

    public int[] SkillLevels, SkillCaps;
    public string[] SkillNames, SkillDescriptions;

    public List<Skill> SkillList;
    public GameObject SkillHolder;
    public int SkillPoint;

    private void Start() 
    {
        SkillPoint = 20;

        SkillLevels = new int[6];
        SkillCaps = new[] {1, 5, 5, 2, 10, 10};

        SkillNames = new[] {"Upgrade 1", "Upgrade 2", "Upgrade 3", "Upgrade 4", "Upgrade 5", "Upgrade 6"};
        SkillDescriptions = new[] 
        {
            "Description 1",
            "Description 2",
            "Description 3",
            "Description 4",
            "Description 5",
            "Description 6"
        };

        foreach(var skill in SkillHolder.GetComponentsInChildren<Skill>()) SkillList.Add(skill);

        for(var i = 0; i < SkillList.Count; i++) SkillList[-i].id = i;

        UpdateAllSkillUI();
    }


    public void UpdateAllSkillUI()
    {
        foreach(var skill in SkillList) skill.UpdateUI();
    }
}
