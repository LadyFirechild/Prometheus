using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Push : MonoBehaviour
{

    public AudioSource pushSource;
    public AudioClip pushClip;
    public new Rigidbody2D rigidbody;

    void Start()
    {
        pushSource.clip = pushClip;
    }

    void Update()
    {
        if (rigidbody.velocity.x >= 1 || rigidbody.velocity.x <= -1f)
        {
            if (!pushSource.isPlaying)
            {
                pushSource.Play();
            }
        }
    }
}
