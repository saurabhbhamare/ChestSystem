using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSlotController 
{
    public ChestSlotView chestSlotView;
    private EventService eventService;
    private ChestSlotState chestSlotState;
    private ChestController chestController;
    public ChestSlotController(ChestSlotView chestSlotView,EventService eventService)
    {
        this.chestSlotView = chestSlotView;
        this.chestSlotView.SetChestSlotController(this);
        this.eventService = eventService;
        SetChestSlotState(ChestSlotState.EMPTY);
    }
    public Transform GetChestTransformParent() => chestSlotView.transform;

    public void SetChestSlotState(ChestSlotState chestSlotState)  {  this.chestSlotState = chestSlotState; }
    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
        SetChestSlotState(ChestSlotState.FILLED);
    }
    public bool IsChestSlotEmpty() => chestSlotState == ChestSlotState.EMPTY;
    public void OnChestClick()
    {
        eventService.OnChestClick.Invoke(this.chestController);       
    }
}
