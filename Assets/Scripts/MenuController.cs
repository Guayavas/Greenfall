using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject[] empresasActivas = new GameObject[12];
    public Personaje personaje;
    public GameObject periodico;
    public GameObject Noticias;
    public Texture2D cursorNormal,cursorMalo,cursorHorrible;
    public Sprite fondoBueno,fondoMedio, fondoMalo;
    public Image imageFondo;
    public GameObject noticia1, noticia2, noticia3, noticia4;
    public AudioSource sonidoMalo, sonidoBueno, SonidoRegular;
    //public Computadora computadora;

    
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        imageFondo = GameObject.Find("FondoVentana").GetComponent <Image>();
        //periodico = GameObject.Find("Periodico");}
        verificarEntorno();
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
                        if (personaje.dia == 1)
                        {
                            periodico.SetActive(true);
                            noticia1.SetActive(true);
                        }
                        break;

                    case "Minasombra S.A.":
                        if (personaje.dia == 4)
                        {
                            periodico.SetActive(true);
                            noticia4.SetActive(true);
                        }
                        break;
                    case "ReverdeCoop":
                        if (personaje.dia == 3)
                        {
                            periodico.SetActive(true);
                            noticia3.SetActive(true);
                        }
                        break;
                    case "EcoHidro S.A.":
                        if (personaje.dia == 4)
                        {
                            periodico.SetActive(true);
                            noticia2.SetActive(true);
                        }
                        break;
                    default:
                        periodico.SetActive(false);
                        noticia1.SetActive(false);
                        noticia2.SetActive(false);
                        noticia3.SetActive(false);
                        noticia4.SetActive(false);
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

    public void verificarEntorno()
    {


        if(personaje.Karma<-55)
        {
            imageFondo.sprite = fondoMalo;
            sonidoMalo.Play();
        }
        else
        {
            if(personaje.Karma <-35)
            {
                imageFondo.sprite = fondoMedio;
                SonidoRegular.Play();
            }
            else
            {
                imageFondo.sprite = fondoBueno;
                sonidoBueno.Play();
            }
            
        }

    }

    public void cambiarCursor()
    {

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
