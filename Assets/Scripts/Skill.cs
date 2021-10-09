using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using static SkillTreeBuild;

public class Skill : MonoBehaviour
{
    public int id;
    public TMP_Text TitleText, DescriptionText;

    public int[] ConnectedSkills;

    public void UpdateUI()
    {
        // {skillTree.SkillLevels[id]} = Current level in skill
        // {skillTree.SkillCaps[id]} = Max level in skill
        // {skillTree.SkillNames[id]} = Display skill name
        TitleText.text = $"{skillTree.SkillNames[id]} {skillTree.SkillLevels[id]}/{skillTree.SkillCaps[id]}";

        DescriptionText.text = $"{skillTree.SkillDescriptions[id]}\nCost: {skillTree.SkillPoint}/1 SP";

        // Get the Image component and change the color field 
        GetComponent<Image>().color = skillTree.SkillLevels[id] >= skillTree.SkillCaps[id] ? Color.yellow
            : skillTree.SkillPoint >= 1 ? Color.green : Color.clear;

            // is each skill visible?
            foreach(var connectedSkill in ConnectedSkills)
            {
                skillTree.SkillList[connectedSkill].gameObject.SetActive(skillTree.SkillLevels[id] > 0);
                skillTree.ConnectorList[connectedSkill].SetActive(skillTree.SkillLevels[id] > 0);
            }
    }

    public void BuySkill()
    {
        Debug.Log("Buy Skill Pressed");
        if(skillTree.SkillPoint < 1 || skillTree.SkillLevels[id] >= skillTree.SkillCaps[id]) return;
        skillTree.SkillPoint -= 1;
        skillTree.SkillLevels[id]++;
        skillTree.UpdateAllSkillUI();
    }
}