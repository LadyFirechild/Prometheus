using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Background : MonoBehaviour
{

    public AudioClip calmClip;
    public AudioSource calmSource;
    public AudioClip rushClip;
    public AudioSource rushSource;
    public PauseMenu pauseMenu;

    void Start()
    {
        calmSource.clip = calmClip;
    }

    void Update()
    {
        if (!calmSource.isPlaying && !pauseMenu.GameIsPaused)
        {
            calmSource.Play();
        }
        if (pauseMenu.GameIsPaused)
        {
            calmSource.Pause();
        }
        if (!pauseMenu.GameIsPaused)
        {
            calmSource.UnPause();
        }
    }

}
