using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestModel 
{
    public ChestType ChestType { get; private set; }
    public Sprite ChestClosedImage { get; private set;  }
    public Sprite ChestOpenedImage { get; private set; }
    public float UnlockTime { get; private set; }
    public float CurrentUnlockTime { get; private set; }

    public string ChestName { get; private set;}
  //  public float CurrentUnlockTime { get; private set; }
    
    public ChestModel(ChestData chestData)
    {
        this.ChestType = chestData.chestType;
        this.ChestClosedImage = chestData.chestClosedImage;
        this.ChestOpenedImage = chestData.chestOpenedImage;
        this.UnlockTime = chestData.unlockTime;
        this.ChestName = chestData.chestName;
        CurrentUnlockTime = UnlockTime;
    }
    
}
