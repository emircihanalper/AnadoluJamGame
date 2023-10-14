using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShieldScript : MonoBehaviour
{
    int hit = 3;
    int element = 1;
    [SerializeField] Image barImage;
    [SerializeField] Slider bar;
    [SerializeField] Color red;
    [SerializeField] Color blue;
    [SerializeField] GameObject finish;
    bool canDamage;
    [SerializeField] GameObject[] shields;
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
            bar.value = (float)hit / 3f;
            if (hit <= 0)
            {
                //Destroy(gameObject);
                //transform.gameObject.tag = "Metal";
                //GetComponent<SpriteRenderer>().color = Color.red;
                hit = 3;
                element = 2;
                barImage.color = red;
                bar.value = 1;
                shields[0].SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Fire") && element==2)
        {
            hit--;
            bar.value = (float)hit / 3f;
            if (hit <= 0)
            {
                //Destroy(gameObject);
                //transform.gameObject.tag = "Onfire";
                //GetComponent<SpriteRenderer>().color = Color.blue;
                hit = 3;
                element = 3;
                barImage.color = blue;
                bar.value = 1;
                shields[1].SetActive(false);
            }
        }

        if (collision.gameObject.CompareTag("Water") && element==3)
        {
            hit--;
            bar.value = (float)hit / 3f;
            if (hit <= 0)
            {
                Destroy(collision.gameObject);
                finish.SetActive(true);
                shields[2].SetActive(false);
                StartCoroutine(goCredits());
                //Destroy(gameObject);
            }
        }
    }

    IEnumerator goCredits()
    {
        yield return new WaitForSeconds(3f);
        finish.SetActive(false);
        SceneManager.LoadScene(2);
    }
}
