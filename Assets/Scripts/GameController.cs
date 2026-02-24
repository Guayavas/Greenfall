using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    [Header("Flujo de juego")]
    public bool verIntro = true;

    [Header("Estado de slot actual")]
    [SerializeField] private int selectedSlot = -1;
    [SerializeField] private SaveData currentSaveData;

    private const int MaxSlots = 3;
    private float sessionStartTime;

    public int SelectedSlot => selectedSlot;
    public SaveData CurrentSaveData => currentSaveData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Jugar()
    {
        if (verIntro)
        {
            SceneManager.LoadScene("SceneIntro");
        }
        else
        {
            SceneManager.LoadScene("SceneMain");
        }
    }

    public void CargarPartida()
    {
        SceneManager.LoadScene("CargarPartida");
    }

    public void SeleccionarSlotYCargar(int slotId)
    {
        if (!SlotEsValido(slotId))
        {
            Debug.LogWarning($"Slot inválido: {slotId}. Usa slots de 1 a {MaxSlots}.");
            return;
        }

        selectedSlot = slotId;
        bool existe = ExistePartida(slotId);
        currentSaveData = existe ? CargarSlot(slotId) : CrearDatosIniciales(slotId);
        ReiniciarSesionJuego();

        if (!existe)
        {
            GuardarPartidaActual();
            Debug.Log($"Se creó una nueva partida en slot {slotId}.");
        }
        else
        {
            Debug.Log($"Partida cargada en slot {slotId}. Tiempo jugado={currentSaveData.totalPlayTimeSeconds:F1}s, Último guardado={currentSaveData.lastSavedAt}");
        }

        Jugar();
    }

    public void GuardarPartidaActual()
    {
        if (!SlotEsValido(selectedSlot) || currentSaveData == null)
        {
            Debug.LogWarning("No se puede guardar: no hay slot seleccionado o no hay datos cargados.");
            return;
        }

        float elapsedSession = Time.realtimeSinceStartup - sessionStartTime;
        if (elapsedSession > 0f)
        {
            currentSaveData.totalPlayTimeSeconds += elapsedSession;
        }

        currentSaveData.TouchTimestamp();

        string json = JsonUtility.ToJson(currentSaveData, true);
        File.WriteAllText(GetSlotPath(selectedSlot), json);
        ReiniciarSesionJuego();

        Debug.Log($"Partida guardada en slot {selectedSlot}: {GetSlotPath(selectedSlot)}");
    }

    public bool ExistePartida(int slotId)
    {
        return SlotEsValido(slotId) && File.Exists(GetSlotPath(slotId));
    }

    public void BorrarPartida(int slotId)
    {
        if (!SlotEsValido(slotId))
        {
            Debug.LogWarning($"No se puede borrar. Slot inválido: {slotId}");
            return;
        }

        string path = GetSlotPath(slotId);
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"Partida borrada del slot {slotId}.");
        }

        if (selectedSlot == slotId)
        {
            selectedSlot = -1;
            currentSaveData = null;
            sessionStartTime = 0f;
        }
    }

    public void Salir()
    {
        Application.Quit();
    }

    private SaveData CargarSlot(int slotId)
    {
        string path = GetSlotPath(slotId);
        string json = File.ReadAllText(path);

        SaveData loadedData = JsonUtility.FromJson<SaveData>(json);
        if (loadedData == null)
        {
            loadedData = CrearDatosIniciales(slotId);
        }

        loadedData.slotId = slotId;
        return loadedData;
    }

    private SaveData CrearDatosIniciales(int slotId)
    {
        return new SaveData(slotId);
    }

    private bool SlotEsValido(int slotId)
    {
        return slotId >= 1 && slotId <= MaxSlots;
    }

    private string GetSlotPath(int slotId)
    {
        return Path.Combine(Application.persistentDataPath, $"save_slot_{slotId}.json");
    }

    private void ReiniciarSesionJuego()
    {
        sessionStartTime = Time.realtimeSinceStartup;
    }
}
