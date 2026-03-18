using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Computadora : MonoBehaviour
{
    public Personaje personaje;
    public GameObject[] dias = new GameObject[4]; 
    public List<string> empresasDisponibles = new List<string>();
    public List<int> empresasValor = new List<int>();
    
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

        empresasValor.Add(100);
        empresasValor.Add(50);
        empresasValor.Add(30);
        empresasValor.Add(141);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
    }

    public void ComprarEmpresa(int empresaOpcion)
    {
        int valorEmpresa = empresasValor[empresaOpcion];
        string empresa = empresasDisponibles[empresaOpcion];

        if (personaje.capitalEconomico >= valorEmpresa && personaje.empresasAdquiridas.Contains(empresa))
        {
            Debug.Log("No alcanza el capital economico o la empresa ya a sido comprada");
        }
        else
        {
            personaje.capitalEconomico = personaje.capitalEconomico - valorEmpresa;
            personaje.empresasAdquiridas.Add(empresa);
            Debug.Log("Empresa comprada");
        }
    }


}
