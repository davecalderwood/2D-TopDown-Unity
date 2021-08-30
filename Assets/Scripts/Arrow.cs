using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject hitEffect;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        
    }
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
