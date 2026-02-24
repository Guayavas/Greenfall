using UnityEngine;

public class CargarPartida : MonoBehaviour
{
    public void CargarSlot(int slotId)
    {
        if (GameController.Instance == null)
        {
            Debug.LogError("No existe GameController en la escena.");
            return;
        }

        GameController.Instance.SeleccionarSlotYCargar(slotId);
    }

    // Métodos de conveniencia para conectar botones desde el Inspector sin parámetros.
    public void CargarSlot1() => CargarSlot(1);
    public void CargarSlot2() => CargarSlot(2);
    public void CargarSlot3() => CargarSlot(3);
}
