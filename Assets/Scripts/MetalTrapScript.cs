using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTrapScript : MonoBehaviour
{
    int hit = 3;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Fire") || collision.gameObject.CompareTag("Stone"))
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
