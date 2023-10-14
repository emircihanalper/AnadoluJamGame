using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetalTrapScript : MonoBehaviour
{
    int hit = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Stone"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            hit++;
            transform.localScale = new Vector3((transform.localScale.x - hit * 0.15f), (transform.localScale.y-hit*0.1f), 1);
            if (hit > 2)
            {
                Destroy(gameObject);
            }

        }
    }
}
