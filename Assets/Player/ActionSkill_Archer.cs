using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSkill_Archer : MonoBehaviour
{
    public static ActionSkill_Archer instance;
    [SerializeField] float actionSkillTimer = 5f;
    [SerializeField] float actionSkillCoolDownTimer = 10f;
    public bool actionSkillActive = false;
    public bool actionSkillOnCooldown = false;

    private void Awake() 
    {
        instance = this;
    }

    private void Update() 
    {
        StartActionSkill();
    }

    public void StartActionSkill() 
    {
        if(Input.GetKeyDown(KeyCode.F) && !actionSkillOnCooldown)
        {
            actionSkillActive = true;

            if(actionSkillTimer != 0)
            {
                StartCoroutine(TimerRoutine());
            }
        }
    }

    private IEnumerator TimerRoutine()
    {
        yield return new WaitForSeconds(actionSkillTimer);
        actionSkillActive = false;
        actionSkillOnCooldown = true;
        StartCoroutine(CoolDownTimer());
    }
    private IEnumerator CoolDownTimer()
    {
        yield return new WaitForSeconds(actionSkillCoolDownTimer);
        actionSkillOnCooldown = false;
    }
}
