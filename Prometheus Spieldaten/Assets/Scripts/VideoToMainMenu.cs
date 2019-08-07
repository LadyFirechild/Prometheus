using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoToMainMenu : MonoBehaviour
{
    public VideoPlayer vp;

    void Awake()
    {
        vp = GetComponent<VideoPlayer>();
    }

    void Start()
    {

        vp.loopPointReached += EndReached;
    }

    void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        SceneManager.LoadScene("Main_Menu");
    }
}
