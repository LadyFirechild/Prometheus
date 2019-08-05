using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{

    public class MorphBigSound : MonoBehaviour
    {
        public MorphNormalSound mns;
        public MorphSmallSound mss;
        public AudioClip BigClip;
        public AudioSource BigSource;
        public bool playerBool = false;
        public float playedTimes = 0;


        void Awake()
        {
            BigSource.clip = BigClip;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerBool = true;
                if (!BigSource.isPlaying && playedTimes == 0)
                {
                    BigSource.Play();
                    Debug.Log("Sound Playing");
                    playerBool = false;
                    playedTimes++;
                    mns.playedTimes = 0;
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
