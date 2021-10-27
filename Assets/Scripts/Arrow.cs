using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;

    private void Start() 
    {
        
    }
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.tag == "Arrow")
        {
            // Physics.IgnoreCollision(other.collider, GetComponent<Collider2D>);
        }
        else
        {
            if(other.collider.tag == "Enemy")
            {
                Debug.Log("Hit Enemy");
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
