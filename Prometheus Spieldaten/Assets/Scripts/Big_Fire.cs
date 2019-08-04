using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Fire : MonoBehaviour
{
    public AudioSource bigFireSource;
    public AudioClip bigFireClip;
    public PauseMenu pauseMenu;

    void Awake()
    {
        bigFireSource.clip = bigFireClip;
    }

    void Start()
    {
        bigFireSource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
      if(!bigFireSource.isPlaying)
        {
            bigFireSource.Play();
        }
        if (pauseMenu.GameIsPaused)
        {
            bigFireSource.Pause();
        }
        if (!pauseMenu.GameIsPaused)
        {
            bigFireSource.UnPause();
        }
    }
}
