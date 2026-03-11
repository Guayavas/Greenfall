using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EstadisticasController : MonoBehaviour
{
    public TMP_Text karma;
    public TMP_Text dinero;
    public TMP_Text empresasAdquiridas;
    public Personaje personaje;
    public int numeral;
    private void Update()
    {
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

    public void Opcion(int opcion)
    {
        switch (opcion) {
            case 0:
                KarmaScore(karma, personaje);
            break;
            case 1:
                DineroScore(dinero,personaje);
                break;

            default:
                break;
                }
    }
}
