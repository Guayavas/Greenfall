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
                }
                else
                {
                    Debug.Log("Inicia Nueva Partida");
                }
                    break;
            case "Partida2":
                break;
            case "Partida3":
                break;
            default:
                break;
        }
    }

    public static bool ExisteSlot(int slot)
    {
        string ruta =
            Application.persistentDataPath +
            "/save_slot_" + slot + ".json";

        return File.Exists(ruta);
    }

}
