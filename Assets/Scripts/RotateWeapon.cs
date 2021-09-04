using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateWeapon : MonoBehaviour
{
    public float offset;

    public Transform shotPoint;
    public GameObject projectile;
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToViewportPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(projectile, shotPoint.position, transform.rotation);
        }
    }
}
