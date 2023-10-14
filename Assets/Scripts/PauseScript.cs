using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public static bool Gamestopped = false;
    public GameObject Pausemenu;

    void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            if (Gamestopped)
            { Continue(); }
            else
            { Stop(); }
        }
    }
    public void Continue()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        Gamestopped = false;
    }
    void Stop()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f; 
        Gamestopped = true;
    }
    public void menu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
