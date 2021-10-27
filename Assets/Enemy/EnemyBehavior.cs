using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float hitPoints;
    public float maxHitPoints = 100f;
    public EnemyHealth healthBar;

    private void Start() 
    {
        hitPoints = maxHitPoints;
        healthBar.SetHealth(hitPoints, maxHitPoints);
    }

    public void TakeDamage(float damage)
    {
        hitPoints -= damage;
        healthBar.SetHealth(hitPoints, maxHitPoints);

        if(hitPoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}
