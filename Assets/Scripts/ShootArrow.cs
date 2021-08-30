using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowForce = 20f;
    // public Camera cam;
    // Vector2 MousePosition;
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot() 
    {
        // Create arrow at firepoint and add force
        
        // Vector2 mousePos = Input.mousePosition;
        // mousePos = cam.ScreenToWorldPoint(new Vector3 (mousePos.x, mousePos.y, cam.transform.position.y - transform.position.y));
        // firePoint.LookAt(mousePos);

        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);
    }
}
