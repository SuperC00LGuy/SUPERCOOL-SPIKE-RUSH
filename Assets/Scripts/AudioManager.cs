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


    void Start()
    {
        musicSource.clip = gameBackground;
        musicSource.PlayOneShot(musicSource.clip);
    }

    
    void Update()
    {
        
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
}
