using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorphNormalSound : MonoBehaviour
{
    public AudioClip NormalClip;
    public AudioSource NormalSource;
    public bool playerBool = false;
    public float playedTimes = 0;


    void Awake()
    {
        NormalSource.clip = NormalClip;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerBool = true;
            if (!NormalSource.isPlaying && playedTimes == 0)
            {
                NormalSource.Play();
                Debug.Log("Sound Playing");
                playerBool = false;
                playedTimes++;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerBool = false;
        }
    }
}
