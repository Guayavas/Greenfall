using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public bool verIntro = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
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

    public void Jugar()
    {
        if (verIntro)
        {
            SceneManager.LoadScene("SceneIntro");
        }
        else
        {
            SceneManager.LoadScene("SceneMain");
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}
