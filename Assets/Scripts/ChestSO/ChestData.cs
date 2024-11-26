
using UnityEngine;

[System.Serializable]
public class ChestData 
{
    public string chestName;
    public ChestType chestType;
    public Sprite chestClosedImage;
    public Sprite chestOpenedImage;
    public float unlockTime;
    public int coins;
    public int gems;
}
