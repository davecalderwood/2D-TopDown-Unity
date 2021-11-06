using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen, player, gameMan, UIOverlay, AudioManagerInstance;
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
        if(AudioManager.instance == null)
        {
            Instantiate(AudioManagerInstance);
        }
    }
}
