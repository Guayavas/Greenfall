using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject[] empresasActivas = new GameObject[12];
    public Personaje personaje;
    public GameObject periodico;
    public GameObject Noticias;
    //public Computadora computadora;

    
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        //periodico = GameObject.Find("Periodico");
        activarPeriodico();
        verificarEmpresas();
    }

    public void activarPeriodico()
    {
        if (personaje.empresasAdquiridas.Count > 0)
        {
            Debug.Log("Entra periodico 1");
            for (int i = 0; i < personaje.empresasAdquiridas.Count; i++)
            {
                string auxEmpresa = personaje.empresasAdquiridas[i];
                switch (auxEmpresa)
                {
                    case "MarAzul Conservación":
                        periodico.SetActive(true);
                            break;
                    default :
                        //periodico.SetActive (false);
                        break;
                }
            }
        }
    }

    public void verNoticia()
    {
        Noticias.SetActive(true );
    }

    public void cerrarPeriodico()
    {
        Noticias.SetActive(false);
    }

    public void verificarEmpresas()
    {
        if(personaje.empresasAdquiridas.Count > 0)
        {
            Debug.Log("Entra 1");
            for (int i = 0; i < personaje.empresasAdquiridas.Count; i++)
            {
                Debug.Log("Entra 2");
                for ( int j = 0; j < empresasActivas.Length;j++)
                {
                    Debug.Log("Entra 3");
                    if (personaje.empresasAdquiridas[i] == empresasActivas[j].name)
                    {
                        empresasActivas[j].SetActive(true);
                        Debug.Log("Si encontro una empresa");
                    }
                }
            }
        }
    }
    public void VolverInicio()
    {
        SceneManager.LoadScene("SceneMenuInicio");
    }

    /*public void CargarPartida()
    {
        GameController.Instance.CargarPartida();
    }*/
    public void Salir()
    {
        Application.Quit();
    }


        
}
