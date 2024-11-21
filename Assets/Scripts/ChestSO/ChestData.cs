
using UnityEngine;

[System.Serializable]
public class ChestData 
{
    [Header("ChestType")]
    public ChestType chestType;
    [Header("Sprites")]
    public Sprite chestClosedImage;
    [Header("Chest Unlock Time")]
    public float unlockTime;
}
