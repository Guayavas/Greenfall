using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UIElements;

public class GuardarInformacion : MonoBehaviour
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
    public static void Guardar(int slot, Personaje personaje)
    {
        string json = JsonUtility.ToJson(personaje);
        string ruta =
            Application.persistentDataPath +
            "/save_slot_" + slot + ".json";
        File.WriteAllText(ruta, json);
    }

    public static void Borrar(int slot)
    {
        string ruta =
            Application.persistentDataPath +
            "/save_slot_" + slot + ".json";

        if (File.Exists(ruta))
        {
            File.Delete(ruta);
            Debug.Log("Archivo del slot " + slot + " borrado correctamente.");
        }
        else
        {
            Debug.Log("No existe archivo en el slot " + slot);
        }
    }


    public void ProbadorGuarda()
    {
        personaje.nombreJugador = "Victor";
        personaje.tiempoJuego = 10;
        personaje.capitalEconomico = 500;
        personaje.nivelContaminacionGlobal = 20;
        personaje.Karma = 2;
        personaje.fechaGuardado = DateTime.Now.ToString("G");
        Guardar(1, personaje);
    }

}
