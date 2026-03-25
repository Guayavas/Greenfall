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
    public TMP_Text Estadisticas;
    public GameObject panel;
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
        panel = GameObject.Find("Panel");
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
        /* switch(opcion)
         {
             case 0:

                 break;
             default: break;
         }*/
        if (personaje.Karma == -35)
        {
            SceneManager.LoadScene("SceneMain");
        }
        else
        {
            panel.SetActive(true);
        }
         
    }

    public void SaltarVideo()   
    {
        Debug.Log("Video saltado por el jugador.");
        SceneManager.LoadScene("SceneMain");
    }

    void OnDestroy()
    {
        if (videoPlayer != null)
            videoPlayer.loopPointReached -= OnVideoFinished;
    }
}
