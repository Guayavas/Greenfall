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
                    Debug.Log("Personaje : " + personaje.fechaGuardado);
                    SceneManager.LoadScene("SceneMain");
                    
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    SceneManager.LoadScene("SceneIntro");
                }
                    break;
            case "Partida2":
                if (ExisteSlot(2))
                {
                    Debug.Log("Carga Partida Slot 2");
                    Cargar(2);
                    //SceneManager.LoadScene("SceneMain");
                    Debug.Log("Personaje : " + personaje.fechaGuardado);
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    SceneManager.LoadScene("SceneIntro");
                }
                break;
            case "Partida3":
                if (ExisteSlot(3))
                {
                    Debug.Log("Carga Partida Slot 3");
                    Cargar(3);
                    //SceneManager.LoadScene("SceneMain");
                    Debug.Log("Personaje : " + personaje.fechaGuardado);
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                    SceneManager.LoadScene("SceneIntro");
                }
                break;
            default:
                break;
        }
    }

    public void CargarEnPersonaje(int slot)
    {
        string ruta = Application.persistentDataPath +
                        "/save_slot_" + slot + ".json";

        if (!File.Exists(ruta))
            return;

        string json = File.ReadAllText(ruta);

        JsonUtility.FromJsonOverwrite(json, personaje);
    }
    public void Cargar(int slot)
    {
        string ruta = Application.persistentDataPath +
                        "/save_slot_" + slot + ".json";

        if (!File.Exists(ruta))
            return;

        string json = File.ReadAllText(ruta);

        JsonUtility.FromJsonOverwrite(json, personaje);
    }

    public static bool ExisteSlot(int slot)
    {
        string ruta =
            Application.persistentDataPath +
            "/save_slot_" + slot + ".json";

        return File.Exists(ruta);
    }

}
