using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataPersonaje 
{
    public string nombreJugador;

    public float tiempoJuego; // segundos acumulados

    public List<string> empresasAdquiridas = new List<string>();

    public float capitalEconomico;

    public float nivelContaminacionGlobal;

    public string fechaGuardado;

    public int Karma;

    public int slotActual;

    public int dia;

    //public int energia;
}
