using System;
using UnityEngine;

[Serializable]
public class SaveData
{
    public int slotId;
    public float totalPlayTimeSeconds;
    public string lastSavedAt;

    public SaveData(int slot)
    {
        slotId = slot;
        totalPlayTimeSeconds = 0f;
        lastSavedAt = DateTime.UtcNow.ToString("o");
    }

    public void TouchTimestamp()
    {
        lastSavedAt = DateTime.UtcNow.ToString("o");
    }
}
