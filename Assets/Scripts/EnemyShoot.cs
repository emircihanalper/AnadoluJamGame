using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform[] Pivotpoints;
    private float timer;
    [SerializeField] Rigidbody2D rb;
    float jumpForce = 8f;
    int count = 3;
    AudioManager audioManager;
    bool isStarted;
    public bool isAlive;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartBoss()
    {
        StartCoroutine(bosswait());
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2 && isStarted && isAlive)
        {
            timer = 0;
            audioManager.Play("Boss");
            StartCoroutine(ShootWait(0.25f));
            count = 3;
        }
    }
    IEnumerator ShootWait(float sec)
    {
        yield return new WaitForSeconds(sec);
        Shoot();
        count--;
        if(count>0)
        {
            StartCoroutine(ShootWait(sec));
        }
    }
    public void Shoot()
    {
        //rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        GameObject mermi=Instantiate(Bullet, Pivotpoints[Random.Range(0,2)].position, Quaternion.identity);
        //mermi.GetComponent<Rigidbody2D>().AddForce(new Vector2(-200f, 400f));
    }

    IEnumerator bosswait()
    {
        yield return new WaitForSeconds(3.25f);
        isStarted = true;
        isAlive = true;
    }    

}
