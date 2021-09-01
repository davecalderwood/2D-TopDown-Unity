using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowForce = 20f;
    // public Camera cam;
    Vector2 MousePosition, lookDirection;
    public float lookAngle;
    void Update()
    {
        lookDirection = Camera.main.WorldToScreenPoint(Input.mousePosition);
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

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

        // Vector3 screen_pos = Camera.main.ScreenToWorldPoint (new Vector3 (MousePosition.x, MousePosition.y, 0));
        // screen_pos.z = transform.position.z;

        // Vector3 direction = (screen_pos - transform.position).normalized;

        // GameObject arrow = Instantiate(arrowPrefab, firePoint.position, Quaternion.identity);

        // Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();

        // rb.AddForce(firePoint.up * arrowForce, ForceMode2D.Impulse);

        GameObject arrow = Instantiate(arrowPrefab);
        arrow.transform.position = firePoint.position;
        arrow.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

        arrow.GetComponent<Rigidbody2D>().velocity = firePoint.up * arrowForce;
    }
}
