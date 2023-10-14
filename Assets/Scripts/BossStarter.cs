using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarter : MonoBehaviour
{
    [SerializeField] EnemyShoot enemyShoot;
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyShoot.StartBoss();
        if (collision.gameObject.tag == "Player")
        uiObject.SetActive(true);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(2.5f);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
