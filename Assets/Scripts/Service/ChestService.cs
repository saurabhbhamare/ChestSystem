using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestService
{
    private ChestSlotView[] chestSlots;
    private ChestSlotController[] chestSlotControllers;
    private ChestSO chestSO;
    private ChestView chestView;
    private EventService eventService;
    public ChestService(ChestSlotView[] chestSlots,ChestSO chestSO,ChestView chestView,EventService eventService)
    {
        this.chestSlots = chestSlots;
        this.chestView = chestView;
        this.chestSO = chestSO;
        this.eventService = eventService;
        chestSlotControllers = new ChestSlotController[chestSlots.Length];
        for(int i = 0; i< chestSlots.Length;i++)
        {
            chestSlotControllers[i] = new ChestSlotController(chestSlots[i],eventService);
            Debug.Log("created slot controllers for every slot ");
        }
        RegisterEventListeners();
        Debug.Log("Length of chest slot controllers" + chestSlotControllers.Length);
    }
   private void RegisterEventListeners()
    {
        eventService.OnGenerateButtonPressed.AddListener(GenerateNewChest);
    }
    private void GenerateNewChest()
    {
        ChestSlotController emptySlot = GetEmptyChestSlot();
       
        if(emptySlot != null)
        {     
            ChestController chestController = new ChestController(GetRandomChestData(),chestView,emptySlot.GetChestTransformParent(),eventService);
            emptySlot.SetChestController(chestController);
        }
        else
        {
            Debug.Log("slot  not available");
        }
    }

    private ChestSlotController GetEmptyChestSlot()
    {
        foreach (var slot in chestSlotControllers)
        {
            if (slot.IsChestSlotEmpty())
            {
                return slot;
            }
        }
        return null;

    }
    public ChestData GetRandomChestData() => chestSO.chests[Random.Range(0,chestSO.chests.Length)];

    private void UnRegisterEventListener()
    {
        eventService.OnGenerateButtonPressed.RemoveListener(GenerateNewChest);
    }
}
