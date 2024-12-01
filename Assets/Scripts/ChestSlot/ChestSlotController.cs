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
        chestSlotView.SetChestSlotStatusText("Empty Slot");
    }
    private void RegisterEventListeners()
    {
       // eventService.OnRemovingChest.AddListener(RemoveChest);
        eventService.OnUnlockedChestClicked.AddListener(RemoveChest);
    }
    public Transform GetChestTransformParent()
    {
        return chestSlotView.transform;
    }
    public void SetChestSlotState(ChestSlotState chestSlotState)
    {
        this.chestSlotState = chestSlotState;
    }
    public void SetChestController(ChestController chestController)
    {
        this.chestController = chestController;
        SetChestSlotState(ChestSlotState.FILLED);
    }
    public bool IsChestSlotEmpty() => chestSlotState == ChestSlotState.EMPTY;
    public ChestController GetChestController() => chestController;
    public void RemoveChest(ChestController chestController)
    {
        Debug.Log("current in RemoveChest");
        SetChestSlotState(ChestSlotState.EMPTY);
        //GetChestController().RemoveGameObject();
        chestController.RemoveGameObject();
        chestSlotView.SetChestSlotStatusText("Empty");
    }
    public void OnChestClick()
    {
        //eventService.ShowNotificationBox.Invoke(chestController.chestModel.ChestType.ToString(), chestController.GetChestState().ToString());
        eventService.OnChestClick.Invoke(this.chestController);
       
    }
    public ChestSlotView GetChestSlotView()
    {
        return chestSlotView;
    }

}
