using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public void setVolume(float volume)
    {
        mainMixer.SetFloat("volume", volume);
    }
    public void setFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void setQuality(int qndex)
    {
        QualitySettings.SetQualityLevel(qndex);
    }
}
