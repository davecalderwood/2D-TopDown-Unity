using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFade : MonoBehaviour
{
    // Create an instance to be called from other scripts
    public static UIFade instance;
    public Image fadeScreen;
    public float fadeTimer = 1f;
    private bool fadeToBlack;
    private bool fadeFromBlack = true;
    void Start()
    {
        // instance is this specific script so other scripts can call functions
        instance = this; 
        // fadeFromBlack = true;

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(fadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeTimer * Time.deltaTime));

            if(fadeScreen.color.a == 1f)
            {
                fadeToBlack = false;
            }
        }

        if(fadeFromBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeTimer * Time.deltaTime));

            if(fadeScreen.color.a == 0f)
            {
                fadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        fadeToBlack = true;
        fadeFromBlack = false;
    }

    public void FadeFromBlack()
    {
        fadeFromBlack = true;
        fadeToBlack = false;
    }
}
