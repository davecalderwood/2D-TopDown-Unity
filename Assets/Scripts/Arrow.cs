using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody2D rb;
    public float damageFormula;
    SpriteRenderer m_SpriteRenderer;

    private void Start() 
    {
        EnemyHealth enemyHealth = rb.transform.GetComponent<EnemyHealth>();
        
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Object.Destroy(gameObject, 2.0f);
        if (ActionSkill_Archer.instance.actionSkillActive)
        {
            m_SpriteRenderer.color = Color.red;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        var enemy = other.collider.GetComponent<EnemyBehavior>();
        if(enemy)
        {
            damageFormula = 10f;

            if (ActionSkill_Archer.instance.actionSkillActive)
            {
                damageFormula = damageFormula * 2;
            }
            enemy.TakeDamage(damageFormula);
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
}
