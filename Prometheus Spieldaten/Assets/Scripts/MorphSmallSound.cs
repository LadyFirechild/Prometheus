using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prometheus
{

    public class MorphSmallSound : MonoBehaviour
    {
        public AudioClip SmallClip;
        public AudioSource SmallSource;
        public bool playerBool = false;
        public float playedTimes = 0;


        void Awake()
        {
            SmallSource.clip = SmallClip;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Player")
            {
                playerBool = true;
                if (!SmallSource.isPlaying && playedTimes == 0)
                {
                    SmallSource.Play();
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
}
