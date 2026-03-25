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
        SceneManager.LoadScene("SceneMain");
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
