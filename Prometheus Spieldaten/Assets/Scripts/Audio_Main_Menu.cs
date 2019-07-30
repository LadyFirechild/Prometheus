using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Main_Menu : MonoBehaviour
{

    public AudioSource MMSource;
    public AudioClip MMClip;

    void Start()
    {
        MMSource.clip = MMClip;
    }

    void Update()
    {
        if (!MMSource.isPlaying)
        {
            MMSource.Play();
        }
    }
}
