using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }
}
