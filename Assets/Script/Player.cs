using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Vector2 move;
    [SerializeField] private float speed;
    [SerializeField] private float jump;
    private bool isJumping;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        
        if (Input.GetKey(KeyCode.Q))
        {
            rb2d.AddTorque(10f);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(new Vector2(rb2d.velocity.x, jump));
        }
    }
    
    private void FixedUpdate()
    {
        rb2d.AddForce(move * speed * Time.deltaTime);
    }
    
    // private void OnCollisionEnter2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         isJumping = true;
    //     }
    //     
    //     if (other.gameObject.CompareTag("DeathGround"))
    //     {
    //         
    //     }
    // }
    //
    // private void OnCollisionExit2D(Collision2D other)
    // {
    //     if (other.gameObject.CompareTag("Ground"))
    //     {
    //         isJumping = false;
    //     }
    // }
}
