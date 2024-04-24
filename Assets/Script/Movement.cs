using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 move;
    private float speed;
    private float jump;
    private bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        speed = 200f;
        jump = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKey(KeyCode.Q))
        {
            rb2d.AddTorque(10f);
        }
        
        if (Input.GetButtonDown("Jump") & isJumping == true)
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jump));
        }
    }
    
    private void FixedUpdate()
    {
        rb2d.AddForce(move * speed * Time.deltaTime);
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
        
        if (other.gameObject.CompareTag("DeathGround"))
        {
            
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
