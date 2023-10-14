using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject Hero;
    private Rigidbody2D rb;
    Vector3 direction;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Hero = GameObject.FindGameObjectWithTag("Player");

        direction= Hero.transform.position - transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x, direction.y).normalized * 375*Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Boss"))
        {
            Destroy(gameObject);
        }
    }
}
