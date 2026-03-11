using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class ColocarInformacion : MonoBehaviour
{
    // Start is called before the first frame update
    public int opcion;
    public TMP_Text text;
    void Start()
    {
        ColocarInformacionSlot(opcion, text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ColocarInformacionSlot(int slot, TMP_Text textoObj)
    {
        Debug.Log("Entra 1");
        string ruta = Application.persistentDataPath + "/slot" + slot + ".json";
        Debug.Log(File.ReadAllText(ruta));

        if (!File.Exists(ruta))
            return;
        
        textoObj.text = "Fecha Guardado: " + File.ReadAllText(ruta);
        Debug.Log("Sale");

    }
}
