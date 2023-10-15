using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStarter : MonoBehaviour
{
    [SerializeField] EnemyShoot enemyShoot;
    public GameObject uiObject;
    AudioManager audioManager;
    void Start()
    {
        uiObject.SetActive(false);
        audioManager = FindObjectOfType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enemyShoot.StartBoss();
        audioManager.Stop("Theme");
        audioManager.Play("BossTheme");
        if (collision.gameObject.tag == "Player")
        uiObject.SetActive(true);
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        Destroy(uiObject);
        Destroy(gameObject);
    }
}
