using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform checkGroundPoint;

    private Rigidbody2D rb;
    private float speed = 6f;
    private float jumpForce = 25f;
    private float checkRadiusRange = 0.2f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<CameraMovement>().SetPlayer(this.gameObject);
    }

    private void FixedUpdate()
    {
        Move();        
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.AddForce(jumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    private void Move()
    {
        float moveTo = Input.GetAxisRaw("Horizontal") * speed;
        rb.velocity = new Vector2(moveTo, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkGroundPoint.position, checkRadiusRange, whatIsGround);
    }

    public void RecieveDamageJump()
    {
        rb.velocity = Vector2.zero;
        rb.AddForce(transform.up * 15f, ForceMode2D.Impulse);
    }
}
