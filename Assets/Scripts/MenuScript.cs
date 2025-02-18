using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public bool game;
    public void PlayGame()
    {
        SceneManager.LoadScene(2);
        game = true;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void Settings()
    {
        SceneManager.LoadScene(1);
        game = false;
    }
}
