using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public float Speed;
    public float jump;
    private float move;

    public Rigidbody2D rb;

    public bool isJumping;
    private bool facingRight=true;

    void Update()
    {
        move = Input.GetAxis("Horizontal");
        if(move!=0){
            animator.SetBool("isRunning",true);
        }
        else{
            animator.SetBool("isRunning",false);
        }
        flipController();
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
    private void flipController()
    {
        if(move>0.1f && facingRight){
            flip();
        }
        else if(move<-0.1f && !facingRight){
            flip();
        }
    }
    private void flip()
    {
        facingRight=!facingRight;
        transform.Rotate(0,180,0);
    }
}