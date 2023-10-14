using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private GameObject Hero;
    private Rigidbody2D rb;
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        Hero = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction= Hero.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x,direction.y).normalized * 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
