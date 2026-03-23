using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EstadisticasController : MonoBehaviour
{
    public TMP_Text karma;
    public TMP_Text dinero;
    public TMP_Text empresaLista;
    public Personaje personaje;

    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
       Opcion();
    }
    public  void KarmaScore(TMP_Text karma, Personaje personaje)
    {
        string texto = "Karma : " + personaje.Karma;
        karma.text = texto;
        //Debug.Log(karma.text);
    }

    public void DineroScore(TMP_Text dinero, Personaje personaje)
    {
        string texto = "Dinero : " + personaje.capitalEconomico;
        dinero.text = texto;
    }
    public void empresasEstadisticas(TMP_Text lista)
    {
        string textoTotal = "";
        Debug.Log("Entra 1");
        if (personaje.empresasAdquiridas.Count > 0) {
            Debug.Log("Entra 2");
            for (int i = 0; i < personaje.empresasAdquiridas.Count; i++)
            {
                textoTotal += personaje.empresasAdquiridas[i] + "\n";
                Debug.Log("Texto Bucle I:"+i + " " + textoTotal);
            }

        }        
        lista.text = "Empresas adquiridas:\n" + textoTotal;
    }
    public void Opcion()
    {
        KarmaScore(karma, personaje);
        DineroScore(dinero,personaje);
        empresasEstadisticas(empresaLista);
    }


}
