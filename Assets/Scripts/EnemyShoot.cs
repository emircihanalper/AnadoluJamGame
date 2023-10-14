using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Pivotpoint;
    private float timer;
    [SerializeField] Rigidbody2D rb;
    float jumpForce = 8f;
    int count = 3;
    AudioManager audioManager;
    bool isStarted;
    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void StartBoss()
    {
        isStarted = true;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 4 && isStarted)
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
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(Bullet, Pivotpoint.position, Quaternion.identity);
    }

}
