using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{

    public class MorphNormalSound : MonoBehaviour
    {
        public MorphBigSound mbs;
        public MorphSmallSound mss;
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
                    mbs.playedTimes = 0;
                    mss.playedTimes = 0;
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
}
