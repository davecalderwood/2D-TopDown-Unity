using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillPointButtons : MonoBehaviour
{
    public Text buttonText;
    public int counter = 0;

    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(counter >= 3)
            {

            }
            else
            {
                counter ++; 
                buttonText.text = "" + counter;
            }
        }
    }
}
