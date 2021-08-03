using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AreaExit : MonoBehaviour
{
    public string areaToLoad;
    public string areaTransitionName;
    public AreaEntrance theEntrance;
    public float waitToLoad = 1f;
    private bool shouldLoadAfterFade;

    private void Start() 
    {
        theEntrance.transitionName = areaTransitionName;
    }
    private void Update() 
    {
        if(shouldLoadAfterFade)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                shouldLoadAfterFade = false;
                SceneManager.LoadScene(areaToLoad);
            }
        }    
    }
    // private void OnTriggerEnter2D(Collider2D other) 
    // {
    //     if(other.tag == "Player")
    //     {
    //         // Delay scene load until after the UI black screen fades in and out
    //         shouldLoadAfterFade = true;
    //         UIFade.instance.FadeToBlack();

    //         PlayerController.instance.areaTransitionName = areaTransitionName;
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            StartCoroutine(LoadNextScene());
        }
    }
 
    private IEnumerator LoadNextScene()
    {
        GameManager.instance.fadingBetweenAreas = true;
        UIFade.instance.FadeToBlack();
        PlayerController.instance.areaTransitionName = areaTransitionName;
        yield return new WaitForSeconds(waitToLoad);
        SceneManager.LoadScene(areaToLoad);
        UIFade.instance.FadeFromBlack();
    }
}
