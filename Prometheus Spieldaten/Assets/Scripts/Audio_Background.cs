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
    public ChaliceCheck chaliceCheck;

    void Start()
    {
        calmSource.clip = calmClip;
    }

    void Update()
    {
        if (!chaliceCheck.bigChalice)
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
        else if (chaliceCheck.bigChalice)
        {
            calmSource.Stop();

            if (!rushSource.isPlaying && !pauseMenu.GameIsPaused)
            {
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
