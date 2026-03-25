using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inutil : MonoBehaviour
{
    public Personaje personaje;
    public SceneController sceneController;
    public TMP_Text text;
    public GameObject indicadorCambio;

    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
    }
    public void DesicionQueFinal()
    {
        if (personaje.Karma > 0)
        {
            SceneManager.LoadScene("SceneFinalBueno");
        }
        else
        {
            SceneManager.LoadScene("SceneFinalMalo");
        }

    }

    public void CambiarDia()
    {
        if (personaje.dia == 4)
        {
            DesicionQueFinal();
        }
        else
        {
           
            personaje.dia++;
            text.text = "Día : " + personaje.dia;
            StartCoroutine(ActivarYDesactivar());
        }
    }
    IEnumerator ActivarYDesactivar()
    {
        indicadorCambio.SetActive(true);
        yield return new WaitForSeconds(3f);
        indicadorCambio.SetActive(false);
    }
}
