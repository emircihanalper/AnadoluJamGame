using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Control : MonoBehaviour
{
    public void Play_button()
    {
        SceneManager.LoadScene(3);
    }
    public void TestBoss()
    {
        SceneManager.LoadScene(7);
    }
    public void Quit_button()
    {
        Application.Quit();
    }

    public void Credits_button()
    {
        SceneManager.LoadScene(2);
    }
    public void Settings_button()
    {
        SceneManager.LoadScene(1);
    }
    public void Return_button()
    {
        SceneManager.LoadScene(0);
    }
}
