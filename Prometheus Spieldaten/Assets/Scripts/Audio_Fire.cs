using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Fire : MonoBehaviour
{
    public AudioClip FireClip;
    public AudioSource FireSource;
    public PauseMenu pauseMenu;

    // Update is called once per frame
    void Start()
    {
        FireSource.clip = FireClip;
    }
    void Update()
    {
        if (!FireSource.isPlaying && !pauseMenu.GameIsPaused)
        {
            FireSource.Play();
            Debug.Log("Audio playing");
        }
        if (pauseMenu.GameIsPaused)
        {
            FireSource.Pause();
        }
        if(!pauseMenu.GameIsPaused)
        {
            FireSource.UnPause();
        }
    }
}
