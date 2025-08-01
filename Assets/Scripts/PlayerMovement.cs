using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float Speed;
    public float jump;

    private float move;

    public Rigidbody2D rb;

    public bool isJumping;

    void Update()
    {
        move = Input.GetAxis("Horizontal");

        rb.linearVelocity = new Vector2(move * Speed, rb.linearVelocity.y);
        if (Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(rb.linearVelocity.x, jump));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Floor"))
        {
            isJumping = false;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isJumping = true;
        }
    }
}