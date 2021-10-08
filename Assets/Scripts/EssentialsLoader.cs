using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen, player, gameMan, UIOverlay;
    void Awake()
    {
        if(UIFade.instance == null)
        {
            Instantiate(UIScreen);
        }
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
        if(GameManager.instance == null)
        {
            Instantiate(gameMan);
        }
        if(GameViewOverlay.instance == null)
        {
            Instantiate(UIOverlay);
        }
    }

    void Update()
    {
        
    }
}
