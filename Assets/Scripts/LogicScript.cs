using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public int highScore;
    public GameObject gameOverScreen;
    public Text scoreText;
    public Text highScoreText;
    public AudioManager sfx;

    void Start()
    {
        this.sfx = FindObjectOfType<AudioManager>();
        scoreText = GameObject.FindGameObjectWithTag("Score").GetComponent<Text>(); //Shit as code am I right
        highScoreText = GameObject.FindGameObjectWithTag("HighScore").GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = highScore.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore++;
        scoreText.text = playerScore.ToString();
        changeHighScore();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        playerScore = 0;
    }
    public void changeHighScore() 
    {
        if (playerScore > highScore)
        {
            sfx.playNewHighScore();
            highScore = playerScore; 
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }

    public void gameOver()
    {   
        gameOverScreen.SetActive(true);
        //scoreText.text = playerScore.ToString(); 
    }
}
