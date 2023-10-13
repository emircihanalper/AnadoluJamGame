using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    float input;
    float speed=10f;
    Vector2 targetVelocity;
    float jumpForce = 12f;
    bool isJumped;
    bool isGrounded=true;
    int jumpCount = 0;
    float lastTimeShoot;
    float coolDown = 0.5f;    
    Animator animator;
    [SerializeField] GameObject yaka;
    [SerializeField] GameObject[] shootObjects;
    [SerializeField] Transform pivotPoint;
    int element = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastTimeShoot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        input = Input.GetAxisRaw("Horizontal");
        if(input>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(input<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        animator.SetBool("isRunning", Mathf.Abs(input) > 0);
        yaka.SetActive(Mathf.Abs(input) > 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumped = true;
        }
        if (Input.GetKeyDown("1"))
        {
            animator.SetTrigger("ChangeFire");
            element = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            animator.SetTrigger("ChangeWater");
            element = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            animator.SetTrigger("ChangeStone");
            element = 3;
        }

        if (Input.GetMouseButtonDown(0) && Time.time-lastTimeShoot>coolDown)
        {
            ObjectShoot();
        }
    }

    private void ObjectShoot()
    {
        GameObject thrownobject = Instantiate(shootObjects[element-1], pivotPoint.position, transform.rotation);
        thrownobject.GetComponent<Rigidbody2D>().AddForce(transform.right * transform.localScale.x * 750);
        lastTimeShoot = Time.time;
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

        } else if(collision.gameObject.CompareTag("Onfire") && element!=1)
        {
            Debug.Log("Die");
        }
    }

}
