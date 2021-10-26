using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public bool canShoot = true;
    public static ShootArrow instance;
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Camera gameCamera;
    public float arrowForce = 20f;
    float lookAngle;
    Vector2 lookDirection;
    public float offset;
    private float angle;

    private void Awake() 
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = CrosshairCursor.instance.mouseCursorPos;

            if(canShoot)
            {
                Shoot();
            }
            else
            {

            }
        }
    }
    void Shoot()
    {
        var screenCam = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 target = CrosshairCursor.instance.mouseCursorPos;

        Vector3 worldMousePos = screenCam;

        // Direction of mouse to player
        Vector2 direction = (Vector2)((worldMousePos - firePoint.position));
        direction.Normalize();

        // Creates the arrow locally
        GameObject arrow = (GameObject)Instantiate (
                                arrowPrefab,
                                firePoint.position + (Vector3)( direction * 0.5f),
                                firePoint.rotation);

        // Adds velocity to the arrow
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;

        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        arrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
    }   
}
