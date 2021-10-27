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
    public GameObject arrowPrefab;

    private void Awake() 
    {
        instance = this;
    }

    // Press Key to activate action skill
    // actionSkillActive becomes true; actionSkillTimer starts
    // when timer runs out actionSkillCoolDownTimer

    private void Update() 
    {
        StartActionSkill();

        if(actionSkillActive)
        {
            // ActionSkill();
        }
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

    public void ActionSkill()
    {
        GameObject go1 = (GameObject)Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);
        GameObject go2 = (GameObject)Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);
        GameObject go3 = (GameObject)Instantiate(arrowPrefab, Vector3.zero, Quaternion.identity);
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
