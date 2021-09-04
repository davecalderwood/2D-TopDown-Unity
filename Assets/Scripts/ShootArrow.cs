using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Camera gameCamera;
    public float arrowForce = 20f;
    float lookAngle;
    Vector2 lookDirection;
    public float offset;
    void Update()
    {
        // lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        // firePoint.rotation = Quaternion.Euler(0, 0, lookAngle);

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 cursorPos = CrosshairCursor.instance.mouseCursorPos;
            Debug.Log("Firepoint Position " + firePoint.position);
            Other();
            // arrowClone.velocity = new Vector2(shootDirection.x * arrowForce, shootDirection.y * arrowForce);
            // Instantiate(arrowPrefab);
            // GameObject arrowClone = Instantiate(arrowPrefab);
            // arrowClone.transform.position = firePoint.position;
            // arrowClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            // arrowClone.GetComponent<Rigidbody2D>().velocity = firePoint.right * arrowForce;
        }

        void Other()
        {
            Vector3 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
            Vector2 direction = (Vector2)((worldMousePos - firePoint.position));
            direction.Normalize ();

            // Creates the bullet locally
            GameObject arrow = (GameObject)Instantiate (
                                    arrowPrefab,
                                    firePoint.position + (Vector3)( direction * 0.5f),
                                    Quaternion.identity);

            lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            arrow.transform.rotation = Quaternion.Euler(0, 0, lookAngle);

            // Adds velocity to the bullet
            arrow.GetComponent<Rigidbody2D> ().velocity = direction * arrowForce;
        }   
    }
}
