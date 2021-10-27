using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerStats[] playerStats;
    public PlayerStats playerOverlay;
    public bool gameMenuOpen, inGameMenuPages, dialogActive, fadingBetweenAreas;
    void Start()
    {
        instance = this;

        HealthSystem healthSystem = new HealthSystem(100);
        Debug.Log("Health System: " + healthSystem.GetHealth());

        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if(gameMenuOpen || inGameMenuPages || dialogActive || fadingBetweenAreas)
        {
            PlayerController.instance.canMove = false;
            ShootArrow.instance.canShoot = false;
            CrosshairCursor.instance.cursorEnabled = false;
        }
        else
        {
            PlayerController.instance.canMove = true;
            ShootArrow.instance.canShoot = true;
            CrosshairCursor.instance.cursorEnabled = true;
        }
    }
}
