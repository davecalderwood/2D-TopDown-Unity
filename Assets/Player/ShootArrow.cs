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
    public float spread;
    private float angle;
    public float coneSize;

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

        if (ActionSkill_Archer.instance.actionSkillActive)
        {
            for (int i = 0; i < 3; i++)
            {
                GameObject arrow = (GameObject)Instantiate (
                            arrowPrefab,
                            firePoint.position + (Vector3)(direction * 0.5f),
                            firePoint.rotation);

                arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;

                angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;

                arrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
            }

            // GameObject arrow1 = (GameObject)Instantiate (
            //     arrowPrefab,
            //     firePoint.position + (Vector3)(direction * 0.5f),
            //     firePoint.rotation);
            // GameObject arrow2 = (GameObject)Instantiate (
            //     arrowPrefab,
            //     firePoint.position + (Vector3)( direction * 0.5f),
            //     firePoint.rotation);
            // GameObject arrow3 = (GameObject)Instantiate (
            //     arrowPrefab,
            //     firePoint.position + (Vector3)( direction * 0.5f),
            //     firePoint.rotation);
                        
            // arrow1.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;
            // arrow2.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;
            // arrow3.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;

            
            // arrow1.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
            // arrow2.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
            // arrow3.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
        }
        else
        {
            // Creates the arrow locally
            GameObject arrow = (GameObject)Instantiate (
                                    arrowPrefab,
                                    firePoint.position + (Vector3)( direction * 0.5f),
                                    firePoint.rotation);

            // Adds velocity to the arrow
            arrow.GetComponent<Rigidbody2D>().velocity = direction * arrowForce;

            // Rotate arrow based on position from player to cursor
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
            arrow.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 1000 * Time.deltaTime);
        }
    }   
}
