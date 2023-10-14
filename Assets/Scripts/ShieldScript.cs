using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    int hit = 3;
    int element = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Stone") || collision.gameObject.CompareTag("Metal"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Stone") && element==1)
        {
            hit--;
            if (hit <= 0)
            {
                //Destroy(gameObject);
                transform.gameObject.tag = "Metal";
                GetComponent<SpriteRenderer>().color = Color.red;
                hit = 3;
            }
        }

        if (collision.gameObject.CompareTag("Fire") && element==2)
        {
            hit--;
            if (hit <= 0)
            {
                //Destroy(gameObject);
                transform.gameObject.tag = "Onfire";
                GetComponent<SpriteRenderer>().color = Color.blue;
                hit = 3;
            }
        }

        if (collision.gameObject.CompareTag("Water") && element==3)
        {
            hit--;
            if (hit <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
