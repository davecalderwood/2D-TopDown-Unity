using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMover : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody2D rb;
    public Camera sceneCamera;
    private Vector2 moveDirection;
    private Vector2 mousePosition;

    private void Update() 
    {
        ProcessInputs();
    }
    private void FixedUpdate() 
    {
        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY);
        mousePosition = sceneCamera.ScreenToViewportPoint(Input.mousePosition);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
