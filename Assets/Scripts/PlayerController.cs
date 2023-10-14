using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

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
    AudioManager audioManager;
    string[] sfxNames= {"Fire" ,"Water","Stone"};
    [SerializeField] GameObject face;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        lastTimeShoot = Time.time;
        audioManager = FindObjectOfType<AudioManager>();
        
    }

    
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
        audioManager.Play(sfxNames[element - 1]);
        if(element==1)
        {
            animator.SetTrigger("Fireball");
        } else if (element == 2)
        {
            animator.SetTrigger("Waterball");
        }
        else if (element == 3)
        {
            animator.SetTrigger("Stoneball");
        }
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

            if(element==1)
            {
                animator.SetBool("isFireJumping", true);
            } 
            else if (element == 2)
            {
                animator.SetBool("isWaterJumping", true);
            }
            else if (element == 3)
            {
                animator.SetBool("isStoneJumping", true);
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            isJumped = false;
            jumpCount = 0;
            animator.SetBool("isFireJumping", false);
            animator.SetBool("isWaterJumping", false);
            animator.SetBool("isStoneJumping", false);           
        }
        else if(collision.gameObject.CompareTag("Onfire") && element!=1)
        {
            animator.SetTrigger("Die");
            face.SetActive(false);
            StartCoroutine(LoadSameScene());
        }
        else if(collision.gameObject.CompareTag("Level"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.gameObject.CompareTag("Die") || collision.gameObject.CompareTag("Empty"))
        {
            animator.SetTrigger("Die");
            face.SetActive(false);
            StartCoroutine(LoadSameScene());
        }
        
    }

    IEnumerator LoadSameScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
