using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
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
    public void InicializarPersonaje(Personaje personaje)
    {
        personaje.tiempoJuego = 0;
        personaje.empresasAdquiridas = 0;
        personaje.capitalEconomico = 1000000;
        personaje.nivelContaminacionGlobal = 0;
        personaje.Karma = 0;
        personaje.fechaGuardado = DateTime.Now.ToString("G");
    }

    public void GetNombre(TMP_Text texto)
    {
        GameObject personajeObj = GameObject.Find("Personaje");
    }    

}
