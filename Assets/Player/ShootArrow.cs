using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    [SerializeField] int numberOfArrowsShot;
    [SerializeField] float projectileSpread;
    // [SerializeField] float startAngle = 90f, endAngle = 270f;
    [SerializeField] float offset;
    public bool canShoot = true;
    public static ShootArrow instance;
    public Transform firePoint;
    public GameObject arrowPrefab;
    public Camera gameCamera;
    public float arrowForce = 20f, spread = 10f, angle;

    private void Awake() 
    {
        instance = this;
    }
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 cursorPos = CrosshairCursor.instance.mouseCursorPos;

            if(canShoot)
            {
                ShootingArrows();
            }
            else
            {

            }
        }
    }
    void ShootingArrows()
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

        FindObjectOfType<AudioManager>().Play("BowShoot");
        
        // Adds velocity to the arrow
        arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;

        // Rotate arrow based on position from player to cursor
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        arrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
    }   
}
