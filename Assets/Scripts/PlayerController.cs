using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float input;
    float speed=10f;
    Vector2 targetVelocity;
    float jumpForce = 10f;
    bool isJumped;
    bool isGrounded=true;
    int jumpCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
        }
        
    }

    private void FixedUpdate()
    {
        targetVelocity = new Vector2(input * speed, rb.velocity.y);
        
        rb.velocity = Vector2.Lerp(rb.velocity, targetVelocity, Time.fixedDeltaTime*10f);
        if (isGrounded && isJumped && jumpCount<2)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
            isJumped = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumped = false;
            jumpCount = 0;
        }
    }

}
