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
    public bool bigChalice = false;

    void Start()
    {
        calmSource.clip = calmClip;
    }

    void Update()
    {
        if (!bigChalice)
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
        if (bigChalice)
        {
            if (!rushSource.isPlaying && !pauseMenu.GameIsPaused)
            {
                calmSource.Stop();
                rushSource.Play();
            }
            if (pauseMenu.GameIsPaused)
            {
                rushSource.Pause();
            }
            if (!pauseMenu.GameIsPaused)
            {
                rushSource.UnPause();
            }
        }
    }

}
