using JetBrains.Annotations;
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
    
    public int slotActual;

    public static Personaje personaje;

    private void Awake()
    {
        
        if(personaje == null)
        {
            personaje = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
