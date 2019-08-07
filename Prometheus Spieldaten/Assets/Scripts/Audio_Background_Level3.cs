using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Background_Level3 : MonoBehaviour
{

    public AudioSource rushSource;
    public AudioClip rushClip;
    public AudioSource thunderSource;
    public AudioClip thunderClip;
    public float thunderPlayed;
    public PauseMenu PauseMenu;
    public Fire_Counter FireCounter;


    void Start()
    {
        rushSource.clip = rushClip;
        thunderSource.clip = thunderClip;
    }

    void Update()
    {
        if (!rushSource.isPlaying && !PauseMenu.GameIsPaused)
        {
            rushSource.Play();
        }
        if (PauseMenu.GameIsPaused)
        {
            rushSource.Pause();
        }
        if (!PauseMenu.GameIsPaused)
        {
            rushSource.UnPause();
        }

        if (FireCounter.collectible == FireCounter.activeFires)
        {
            if (thunderPlayed == 0)
            {
                thunderPlayed++;
                thunderSource.Play();
            }
        }
    }
}
