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
    /*
     * ?	Nombre del jugador
?	Tiempo de juego
?	Empresas adquiridas
?	Capital económico
?	Nivel de contaminación global
?	Fecha y hora de guardado

     */

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void ObtenerInformacion()
    {

    }

    public void ColocarInformacion()
    {
        
    }
}
