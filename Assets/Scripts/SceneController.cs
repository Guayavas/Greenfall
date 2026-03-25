using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    /*
      Esceneas en orden
      0 = SceneMenuInicio
      1 = SceneMain
      2 = SceneIntro
      3 = CargarPartida
      4 = CrearPersonaje
      5 = SceneComputer
     */
   public void CargarScena(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Salir()
    {
        Application.Quit();
    }
}
