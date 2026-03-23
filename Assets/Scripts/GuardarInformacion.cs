using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class GuardarInformacion : MonoBehaviour
{
    public Personaje personaje;
    public ColocarInformacion informacion;
  
    
    // Start is called before the first frame update
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
    }

    public void Guardar()
    {
        int slot = personaje.slotActual;
        personaje.fechaGuardado = DateTime.Now.ToString("g");
        Debug.Log("Este es el slot actual " + slot);
        string json = JsonUtility.ToJson(personaje);
        string ruta =
            Application.persistentDataPath +
            "/save_" + slot + ".json";
        Debug.Log("Si sale " + slot);
        File.WriteAllText(ruta, json);
    }

    public void Borrar(int slot)
    {
        string ruta =
            Application.persistentDataPath +
            "/save_" + slot + ".json";

        if (File.Exists(ruta))
        {
            File.Delete(ruta);
            for (int i = 1; i <= 3; i++)
            {
                informacion.ColocarInformacionSlot(i);
            }
          
            Debug.Log("Archivo del slot " + slot + " borrado correctamente.");
        }
        else
        {
            Debug.Log("No existe archivo en el slot " + slot);
        }
    }

    public void setNombre(TMP_Text texto)
    {
        personaje.nombreJugador = texto.text;
    }

}
