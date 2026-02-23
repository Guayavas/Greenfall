using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicController : MonoBehaviour
{
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;   
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        MarcarIntroComoVista();
        SceneManager.LoadScene("SceneMain");
    }

    public void SaltarVideo()   // Llama esto desde un botón UI o en Update()
    {
        MarcarIntroComoVista();
        SceneManager.LoadScene("SceneMain");
    }

    //cambia el valor a false
    private void MarcarIntroComoVista()
    {
        if (GameController.Instance != null)
        {
            GameController.Instance.verIntro = false;
            Debug.Log("Intro marcada como vista (verIntro = false)");
        }
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
