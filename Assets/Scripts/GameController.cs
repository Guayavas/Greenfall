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

    public void DesicionQueFinal()
    {
        if (personaje.Karma > 0)
        {
            sceneController.CargarScena(8);
        }
        else
        {
            sceneController.CargarScena(9);
        }
            
    }

    public void CambiarDia()
    {
        if(personaje.dia == 4)
        {
            DesicionQueFinal();             
        }
        else
        {
            personaje.dia++;
        }
    }

    public void Salir()
    {
        Application.Quit();
    }
}
