using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    Personaje personaje;
    SceneController sceneController;
    void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

  

    
}
