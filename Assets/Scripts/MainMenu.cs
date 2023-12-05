using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadEmbraceLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadLevel_1()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadLevel_2()
    {
        SceneManager.LoadScene(3);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
