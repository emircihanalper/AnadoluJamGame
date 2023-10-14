using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    public GameObject Bullet;
    public Transform Pivotpoint;
    private float timer;
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > 2)
        {
            timer = 0;
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(Bullet, Pivotpoint.position, Quaternion.identity);
    }

}
