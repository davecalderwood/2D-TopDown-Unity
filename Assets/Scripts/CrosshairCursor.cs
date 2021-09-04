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
    }
}
