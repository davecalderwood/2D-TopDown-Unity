using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float arrowDamage;

    private void Start() 
    {
        EnemyHealth enemyHealth = rb.transform.GetComponent<EnemyHealth>();
    }
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var enemy = other.collider.GetComponent<EnemyBehavior>();
        if(enemy)
        {
            enemy.TakeDamage(10);
        }

        if(other.collider.tag == "Arrow")
        {
            // Physics.IgnoreCollision(other.collider, GetComponent<Collider2D>);
        }
        else
        {
            if(other.collider.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
    }

    public void DoDamage()
    {

    }
}
