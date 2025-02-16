using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("==========Audio Source===========")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;

    [Header("==========Audio Clip===========")]
    public AudioClip gameBackground;
    public AudioClip menuBackground;
    public AudioClip applePoint;
    public AudioClip death;
    public AudioClip deathToAll;
    public AudioClip highScore;

    public float backgroundTimeRate = 0.0f;
    public const float BACKGROUNDTIMER = 220.0f;

    void Start()
    {
        playGameBackground();
    }

    
    void Update()
    {
        if (backgroundTimeRate < BACKGROUNDTIMER)
        {
            backgroundTimeRate = backgroundTimeRate + Time.deltaTime;
        }
        else
        {
            Debug.Log("SHOULD HAVE PLAYED AGAIN");
            playGameBackground();
            backgroundTimeRate = 0;
        }
    }
    public void playMenuBackground()
    {
        musicSource.clip = menuBackground;
        musicSource.PlayOneShot(musicSource.clip);
    }
    public void playAppleSFX()
    {
        musicSource.clip = applePoint;
        musicSource.PlayOneShot(musicSource.clip);
    }
    public void playDeath() 
    {
        musicSource.clip = death;
        musicSource.PlayOneShot(musicSource.clip);
    }
    public void playNewHighScore()
    {
        musicSource.clip = highScore;
        musicSource.PlayOneShot(musicSource.clip);
    }
    public void playGameBackground()
    {
        musicSource.clip = gameBackground;
        musicSource.PlayOneShot(musicSource.clip);
    }
}
