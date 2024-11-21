using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestController 
{
    private ChestView chestView;
  public ChestController(ChestData chestData,ChestView chestView,Transform parentTransform, EventService eventService)
    {
        this.chestView = GameObject.Instantiate<ChestView>(chestView, parentTransform);
    }
}
