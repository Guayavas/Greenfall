using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class EstadisticasController : MonoBehaviour
{
    public TMP_Text karma;
    public TMP_Text dinero;
    public TMP_Text empresasAdquiridas;
    public TMP_Text empresaLista;
    public Personaje personaje;
    public int numeral;
    private void Update()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        Opcion(numeral);
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
                textoTotal = personaje.empresasAdquiridas[i] + "\n";
                
            }

        }        
        lista.text = "Empresas adquiridas:\n" + textoTotal;
    }
    public void Opcion(int opcion)
    {
        switch (opcion) {
            case 0:
                KarmaScore(karma, personaje);
            break;
            case 1:
                DineroScore(dinero,personaje);
                break;
            case 2:
                empresasEstadisticas(empresaLista);
                break;
            default:
                break;
            }



    }


}
