using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotController 
{
    private ChestSlotView chestSlotView;
    private EventService eventService;
    private ChestSlotState chestSlotState;
    private ChestController chestController;
    public ChestSlotController(ChestSlotView chestSlotView,EventService eventService)
    {
        this.chestSlotView = chestSlotView;
        this.eventService = eventService;
        SetChestSlotState(ChestSlotState.EMPTY);
    }
    public Transform GetChestTransformParent()
    {
        return chestSlotView.transform;
    }
    public void SetSlotFillStatus(bool status)
    {
     //   isEmpty = status;
    }
    
    private void SetChestSlotState(ChestSlotState chestSlotState)
    {
        this.chestSlotState = chestSlotState;
    }
    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
        SetChestSlotState(ChestSlotState.FILLED);
    }

    public bool IsChestSlotEmpty() => chestSlotState == ChestSlotState.EMPTY;
}
