using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        if(PlayerController.instance == null)
        {
            Instantiate(player);
        }
    }

    void Update()
    {
        
    }
}
