using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    int hit = 3;
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

        if (collision.gameObject.CompareTag("Water"))
        {
            hit--;
            if (hit <= 0)
            {
                Destroy(gameObject);
            }

        }
    }
}
