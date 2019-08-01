using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings_Test : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volumeMaster", volume);
    }

}
