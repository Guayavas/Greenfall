using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject[] empresasActivas = new GameObject[12];
    public Personaje personaje;
    public Computadora computadora;

    
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        verificarEmpresas();

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

    public void CargarPartida()
    {
        GameController.Instance.CargarPartida();
    }
    public void Salir()
    {
        Application.Quit();
    }


        
}
