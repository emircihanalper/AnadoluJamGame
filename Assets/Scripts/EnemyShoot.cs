using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Pivotpoint;
    private float timer;
    [SerializeField] Rigidbody2D rb;
    float jumpForce = 12f;
    int count = 3;
    private void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 4)
        {
            timer = 0;
            StartCoroutine(ShootWait(0.5f));
        }
    }
    IEnumerator ShootWait(float sec)
    {
        yield return new WaitForSeconds(sec);
        Shoot();
        count--;
        if(count>0)
        {
            StartCoroutine(ShootWait(0.5f));
        }
    }
    public void Shoot()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        Instantiate(Bullet, Pivotpoint.position, Quaternion.identity);
    }

}
