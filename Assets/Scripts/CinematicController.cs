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

    void Update()
    {
        // Si el jugador presiona una tecla para saltar el video
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaltarVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        MarcarIntroComoVista();
        SceneManager.LoadScene("SceneMain");
    }

    public void SaltarVideo()   // Llama esto desde un bot�n UI o en Update()
    {
        Debug.Log("Video saltado por el jugador.");
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
