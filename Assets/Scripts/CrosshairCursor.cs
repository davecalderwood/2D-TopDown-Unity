using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairCursor : MonoBehaviour
{
    public static CrosshairCursor instance;
    float angle;
    public Vector2 mouseCursorPos, shootDirection;
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowForce = 20f;
    void Awake()
    {        
        instance = this;
        Cursor.visible = false;
    }

    void Update() 
    {
        GetMousePosition();
    }

    void GetMousePosition()
    {
        mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
        
        angle = Mathf.Atan2(mouseCursorPos.y, mouseCursorPos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Cursor Postion: " + mouseCursorPos);
            Debug.Log("Firepoint Postion: " + firePoint.position);

            // Other();
        }
    }

    private void Shoot()
    {
        // Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        // // shootDirection = firePoint.position - mouseCursorPos;

        // Vector2 direction = (Vector2)((mouseCursorPos - firePoint.position));
        // direction.Normalize();
    }

    void Other()
    {
        Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        Vector2 direction = (Vector2)((worldMousePos - transform.position));
        direction.Normalize ();

        // Creates the bullet locally
        GameObject bullet = (GameObject)Instantiate (
                                arrowPrefab,
                                transform.position + (Vector3)( direction * 0.5f),
                                Quaternion.identity);

        // Adds velocity to the bullet
        bullet.GetComponent<Rigidbody2D> ().velocity = direction * arrowForce;
    }
}
