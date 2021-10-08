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
    public GameObject SkillHolder, ConnectorHolder;
    public List<GameObject> ConnectorList;
    public int SkillPoint;

    public void Start() 
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
        foreach(var connector in ConnectorHolder.GetComponentsInChildren<RectTransform>()) ConnectorList.Add(connector.gameObject);

        for(var i = 0; i < SkillList.Count; i++) SkillList[i].id = i;

        SkillList[0].ConnectedSkills = new[] {1, 2, 3};
        SkillList[2].ConnectedSkills = new[] {4, 5};

        UpdateAllSkillUI();
    }


    public void UpdateAllSkillUI()
    {
        foreach(var skill in SkillList) skill.UpdateUI();
    }
}