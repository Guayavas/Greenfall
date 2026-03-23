using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class CargarPartida : MonoBehaviour
{
    public Personaje personaje;
    // Start is called before the first frame update
    void Start()
    {
       personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void CargarSlot(UnityEngine.UI.Button button)
    {
        string nombre = button.gameObject.name;

        //Debug.Log(nombre);

        switch (nombre)
        {
            case "Partida1":
                if(ExisteSlot(1))
                {
                    Debug.Log("Carga Partida Slot 1");
                    Cargar(1);
                    personaje.slotActual = 1;
                    SceneManager.LoadScene("SceneMain");
                    
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    InicializarPersonaje();
                    personaje.slotActual = 1;
                    SceneManager.LoadScene("CrearPersonaje");
                }
                    break;
            case "Partida2":
                if (ExisteSlot(2))
                {
                    Debug.Log("Carga Partida Slot 2");
                    Cargar(2);
                    personaje.slotActual = 2;
                    //SceneManager.LoadScene("SceneMain");
                    Debug.Log("Personaje : " + personaje.fechaGuardado);
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    InicializarPersonaje();
                    personaje.slotActual = 2;
                    SceneManager.LoadScene("CrearPersonaje");
                }
                break;
            case "Partida3":
                if (ExisteSlot(3))
                {
                    Debug.Log("Carga Partida Slot 3");
                    Cargar(3);
                    personaje.slotActual = 3;
                    //SceneManager.LoadScene("SceneMain");
                    Debug.Log("Personaje : " + personaje.fechaGuardado);
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    InicializarPersonaje();
                    personaje.slotActual = 3;
                    SceneManager.LoadScene("CrearPersonaje");
                }
                break;
            default:
                break;
        }
    }

    public void Cargar(int slot)
    {
        string ruta = Application.persistentDataPath +
                        "/save_" + slot + ".json";

        if (!File.Exists(ruta))
            return;

        string json = File.ReadAllText(ruta);

        JsonUtility.FromJsonOverwrite(json, personaje);
    }

    public static bool ExisteSlot(int slot)
    {
        string ruta =
            Application.persistentDataPath +
            "/save_" + slot + ".json";
        Debug.Log(File.Exists(ruta) + "Esta seria ");
        return File.Exists(ruta);
    }

    public void InicializarPersonaje()
    {
        personaje.tiempoJuego = 0;
        personaje.empresasAdquiridas.Clear();
        personaje.capitalEconomico = 1000000;
        personaje.nivelContaminacionGlobal = 0;
        personaje.Karma = 0;
        personaje.fechaGuardado = DateTime.Now.ToString("g");
        personaje.dia = 1;
    }

}
