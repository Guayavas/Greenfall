using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Personaje : MonoBehaviour
{
    public string nombreJugador;

    public float tiempoJuego; // segundos acumulados

    public int empresasAdquiridas;

    public float capitalEconomico;

    public float nivelContaminacionGlobal;

    public string fechaGuardado;

    public int Karma;
 

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

}
