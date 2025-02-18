using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public MenuScript isGamePlaying;
    public GameObject pauseMenuScreen;

    // Start is called before the first frame update
    void Start()
    {
        isGamePlaying = FindObjectOfType<MenuScript>();
    }
    public void pauseGame()
    {
        if (isGamePlaying.game == true)
        {
            Time.timeScale = 0.0f;
        }
        pauseMenuScreen.SetActive(true);
    }
    public void resumeGame()
    {
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
