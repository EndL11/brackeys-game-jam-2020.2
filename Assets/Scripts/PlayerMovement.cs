using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask whatIsGround;
    public Transform checkGroundPoint;

    private Rigidbody2D rb;
    private float speed = 6f;
    private float jumpForce = 20f;
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

        //if(Input.GetAxisRaw("Horizontal") != 0)
        //{
        //    Vector2 newPos = transform.position;
        //    newPos.x += Input.GetAxisRaw("Horizontal");
        //    transform.position = Vector2.MoveTowards(transform.position, newPos, speed * Time.deltaTime);
        //}
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(checkGroundPoint.position, checkRadiusRange, whatIsGround);
    }
}
