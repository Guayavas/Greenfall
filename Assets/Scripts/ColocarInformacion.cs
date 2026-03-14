using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class ColocarInformacion : MonoBehaviour
{
    // Start is called before the first frame update
    public int opcion;
    public TMP_Text nombre;
    public TMP_Text fecha;
    public TMP_Text tiempo;

    public GameObject datosObject;
    public GameObject defaultObject;
    private void Awake()
    {
        ColocarInformacionSlot(opcion);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColocarInformacionSlot(int slot)
    {
        Debug.Log("Entra 1");
        string ruta = Application.persistentDataPath + "/save_" + slot + ".json";
        //Debug.Log(File.ReadAllText(ruta));

        if (!File.Exists(ruta)) 
        {
            Debug.Log("No existe la ruta " + ruta);
            defaultObject.SetActive(true);
            datosObject.SetActive(false);
            return; 
        }

        defaultObject.SetActive(false);
        datosObject.SetActive(true);

        string json = File.ReadAllText(ruta);
        DataPersonaje auxPersonaje = JsonUtility.FromJson<DataPersonaje>(json);

        nombre.text = "Nombre: " + auxPersonaje.nombreJugador;
        tiempo.text = "Tiempo Jugado: " + auxPersonaje.tiempoJuego;
        fecha.text = "Fecha: " + auxPersonaje.fechaGuardado;
        Debug.Log("Sale");

    }
}
