using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Computadora : MonoBehaviour
{
    public Personaje personaje;
    public GameObject[] dias = new GameObject[4]; 
    public List<string> empresasDisponibles = new List<string>();
    public List<int> empresasValor = new List<int>();
    public List<int> valorKarma =   new List<int>();
    public EstadisticasController estadisticasController;
    
    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        dias[personaje.dia-1].SetActive(true);
        LlenarEmpresas();
    }

    public void LlenarEmpresas()
    {
        empresasDisponibles.Add("MarAzul Conservación");
        empresasDisponibles.Add("PetroDominion");
        empresasDisponibles.Add("CarbónVast");
        empresasDisponibles.Add("SolisTech");
        empresasDisponibles.Add("PlastiMax Industries");
        empresasDisponibles.Add("ReverdeCoop");
        empresasDisponibles.Add("Minasombra S.A.");
        empresasDisponibles.Add("EcoHidro S.A.");        
            
        empresasDisponibles.Add("CírculoVerde Reciclaje");  
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

        valorKarma.Add(-1);
        valorKarma.Add(-10);
        valorKarma.Add(5);
        valorKarma.Add(10);
        valorKarma.Add(-8);
        valorKarma.Add(8);
        valorKarma.Add(-7);
        valorKarma.Add(-1);
        valorKarma.Add(-1);
        valorKarma.Add(6);
        valorKarma.Add(-1);

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
            personaje.Karma += valorKarma[empresaOpcion];
            
            Debug.Log("Empresa comprada");
        }
        estadisticasController.Opcion();
    }

    public void venderEmpresa(int empresaOpcion)
    {
        int valorEmpresa = empresasValor[empresaOpcion];
        string empresa = empresasDisponibles[empresaOpcion];

        if (personaje.empresasAdquiridas.Contains(empresa))
        {
            personaje.capitalEconomico += valorEmpresa;
            personaje.empresasAdquiridas.Remove(empresa);
            Debug.Log("Se vendio la empresa");
        }
        else
        {
            Debug.Log("No posee la empresa no se puede vender");
        }
        estadisticasController.Opcion();
    }


}
