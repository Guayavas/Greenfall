using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inutil : MonoBehaviour
{
    public Personaje personaje;
    public SceneController sceneController;
    public TMP_Text text;
    public GameObject indicadorCambio;
    public List<int> gananciasEmpresas = new List<int>();

    private void Awake()
    {
        personaje = GameObject.Find("Personaje").GetComponent<Personaje>();
        llenarLista();
    }
    public void DesicionQueFinal()
    {
        if (personaje.Karma > 0)
        {
            SceneManager.LoadScene("SceneFinalBueno");
        }
        else
        {
            SceneManager.LoadScene("SceneFinalMalo");
        }

    }

    public void CambiarDia()
    {
        if (personaje.dia == 4)
        {
            DesicionQueFinal();
        }
        else
        {           
            personaje.dia++;
            text.text = "Día : " + personaje.dia;
            sumarGanancias();
            StartCoroutine(ActivarYDesactivar());
        }
    }

    public void llenarLista()
    {
        gananciasEmpresas.Add(8000);
        gananciasEmpresas.Add(65000);
        gananciasEmpresas.Add(48000);
        gananciasEmpresas.Add(19000);
        gananciasEmpresas.Add(42000);
        gananciasEmpresas.Add(22000);
        gananciasEmpresas.Add(15000);
        gananciasEmpresas.Add(52000);
    }

    public void sumarGanancias()
    {
        if(personaje.empresasAdquiridas.Count > 0)
        {
            for (int i = 0; i < personaje.empresasAdquiridas.Count; i++)
            {
                string empresa = personaje.empresasAdquiridas[i];

                switch (empresa)
                {
                    case "MarAzul Conservación":
                        personaje.capitalEconomico += gananciasEmpresas[0];
                        break;

                    case "PetroDominion":
                        personaje.capitalEconomico += gananciasEmpresas[1];
                        break;

                    case "CarbónVast":
                        personaje.capitalEconomico += gananciasEmpresas[2];
                        break;

                    case "SolisTech":
                        personaje.capitalEconomico += gananciasEmpresas[3];
                        break;

                    case "PlastiMax Industries":
                        personaje.capitalEconomico += gananciasEmpresas[4];
                        break;

                    case "ReverdeCoop":
                        personaje.capitalEconomico += gananciasEmpresas[5];
                        break;

                    case "Minasombra S.A.":
                        personaje.capitalEconomico += gananciasEmpresas[6];
                        break;

                    case "EcoHidro S.A.":
                        personaje.capitalEconomico += gananciasEmpresas[7];
                        break;
                    default:
                        break;
                }
            }
        }
        
    }
    IEnumerator ActivarYDesactivar()
    {
        indicadorCambio.SetActive(true);
        yield return new WaitForSeconds(3f);
        indicadorCambio.SetActive(false);
    }
}
