using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarter : MonoBehaviour
{
    [SerializeField] EnemyShoot enemyShoot;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyShoot.StartBoss();
    }
}
