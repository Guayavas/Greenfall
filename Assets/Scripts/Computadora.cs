using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computadora : MonoBehaviour
{
    public Personaje personaje;
    public GameObject[] dias = new GameObject[4]; 
    public List<string> empresasDisponibles = new List<string>();
    
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        dias[personaje.dia-1].SetActive(true);
        LlenarEmpresas();
    }

    public void LlenarEmpresas()
    {
        empresasDisponibles.Add("EcoHidro S.A.");
        empresasDisponibles.Add("SolisTech");
        empresasDisponibles.Add("ReverdeCoop");
        empresasDisponibles.Add("MarAzul Conservación");
        empresasDisponibles.Add("CírculoVerde Reciclaje");
        empresasDisponibles.Add("PetroDominion");
        empresasDisponibles.Add("Minasombra S.A.");
        empresasDisponibles.Add("CarbónVast");
        empresasDisponibles.Add("PlastiMax Industries");
        empresasDisponibles.Add("AgroTox Global");
        empresasDisponibles.Add("FastWear Group");
        empresasDisponibles.Add("ArrastreCorp");
    }

    public void ComprarEmpresa(int empresaOpcion)
    {
        
    }


}
