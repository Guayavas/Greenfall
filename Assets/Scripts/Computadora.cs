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

        empresasValor.Add(65000);
        empresasValor.Add(220000);
        empresasValor.Add(160000);
        empresasValor.Add(120000);
        empresasValor.Add(140000);
        empresasValor.Add(1400000);
        empresasValor.Add(180000);
        empresasValor.Add(95000);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);
        empresasValor.Add(100);

        valorKarma.Add(20);
        valorKarma.Add(-30);
        valorKarma.Add(-24);
        valorKarma.Add(22);
        valorKarma.Add(-20);
        valorKarma.Add(22);
        valorKarma.Add(18);
        valorKarma.Add(-26);
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
