using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrapScript : MonoBehaviour
{
    int hit = 3;
    [SerializeField] SpriteRenderer[] renderers;
    [SerializeField] Sprite[] cracks;
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
        
        if (collision.gameObject.CompareTag("Stone"))
        {
            hit--;
            if (hit <= 0)
            {
                Destroy(gameObject);
            }
            else
            {
                foreach (SpriteRenderer r in renderers)
                {
                    r.sprite = cracks[hit - 1];
                }
            }

        }
    }
}
