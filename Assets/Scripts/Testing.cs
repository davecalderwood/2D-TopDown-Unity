using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private PlayerStats player;
    [SerializeField] private SkillTree uiSkillTree;

    private void Start() 
    {
        uiSkillTree.SetPlayerSkills(player.GetPlayerSkills());
    }
}
