using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Fire : MonoBehaviour
{
    public AudioClip FireClip;
    public AudioSource FireSource;

    // Update is called once per frame
    void Start()
    {
        FireSource.clip = FireClip;
    }
    void Update()
    {
        FireSource.Play();
        Debug.Log("Audio playing");
    }
}
