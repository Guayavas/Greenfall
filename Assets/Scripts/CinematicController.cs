using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class CinematicController : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    public Personaje personaje;
    //public TMP_Text Estadisticas;
    //public GameObject panel;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
        //panel = GameObject.Find("Panel");
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
    }



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaltarVideo();
        }
    }

    void OnVideoFinished(VideoPlayer vp) // (VideoPlayer vp,int opcion)
    {
        Debug.Log("Video saltado por el jugador.");
        if (personaje.Karma == -35)
        {
            SceneManager.LoadScene("SceneMain");
        }
        else
        {
            SceneManager.LoadScene("FinalCreditos");
        }

    }

    public void SaltarVideo()   
    {
        Debug.Log("Video saltado por el jugador.");
        if (personaje.Karma == -35)
        {
            SceneManager.LoadScene("SceneMain");
        }
        else
        {
            SceneManager.LoadScene("FinalCreditos");
        }
        
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
