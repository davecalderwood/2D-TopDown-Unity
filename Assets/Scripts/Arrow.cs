using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    // public GameObject hitEffect;
    public Rigidbody2D rb;
    private void OnCollisionEnter2D(Collision2D other) 
    {
        rb.isKinematic = true;
    }
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }
}
