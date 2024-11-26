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
    private Queue<ChestController> chestControllerQueue;
    private ChestController currentChestController; 
    private int queueCount=2;

    public ChestService(ChestSlotView[] chestSlots,ChestSO chestSO,ChestView chestView,EventService eventService)
    {
        this.chestSlots = chestSlots;
        this.chestView = chestView;
        this.chestSO = chestSO;
        this.eventService = eventService;
        chestSlotControllers = new ChestSlotController[chestSlots.Length];
        chestControllerQueue = new Queue<ChestController>();
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
        eventService.OnChestClick.AddListener(OnChestClick);
        eventService.OnTimeButtonClick.AddListener(OnTimerButtonClick);
        eventService.OnGemsButtonClick.AddListener(UnlockChest);
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
        eventService.OnChestClick.RemoveListener(OnChestClick);
        eventService.OnTimeButtonClick.RemoveListener(OnTimerButtonClick);
        eventService.OnGemsButtonClick.RemoveListener(UnlockChest);
    }
    private void OnChestClick(ChestController chestController)
    {
        switch (chestController.GetChestState())
        {
            case ChestStates.LOCKED:
                eventService.ShowLockedStateNotificationBox.Invoke(chestController.chestModel.ChestName, string.Format("Unlock {0}.", chestController.chestModel.ChestName));
                eventService.SetTimeButtonText.Invoke(string.Format("{0:00}:{1:00}:{2:00}", Mathf.FloorToInt(chestController.chestModel.CurrentUnlockTime / 3600),
                    Mathf.FloorToInt((chestController.chestModel.CurrentUnlockTime % 3600) / 60), Mathf.FloorToInt(chestController.chestModel.CurrentUnlockTime % 60)));
                break;
            case ChestStates.UNLOCKING:
                eventService.ShowUnlockingStateNotificationBox.Invoke(chestController.chestModel.ChestName, string.Format("Unlock {0}.", chestController.chestModel.ChestName));
                break;
            case ChestStates.UNLOCKED:
                OnUnlockedChestClick(currentChestController);
                break;
        }
    }
    //about queue
    private int GetQueueCount()
    {
        return chestControllerQueue.Count;
    }
    private void EnqueueChest(ChestController controller)
    {
        if(QueueHasSpace())
        {
            controller.ChangeChestState(ChestStates.QUEUED);
            chestControllerQueue.Enqueue(controller);
            if(currentChestController== null)
            {
                DequeueChest();
            }
        }
        else
        {
            eventService.ShowNotificationBox.Invoke("Chest Queue", "Chest Queue is full .Please Try again later");
        }
    }
    private void DequeueChest()
    {
         if(GetQueueCount()>0)
        {
            ChestController controller = chestControllerQueue.Dequeue();
            currentChestController = controller;
            currentChestController.ChangeChestState(ChestStates.UNLOCKING);
        }
        else
        {
            currentChestController = null;
        }
    }
    private bool QueueHasSpace()
    {
        return GetQueueCount() > queueCount;
    }
    private void OnUnlockedChestClick(ChestController chestController)
    {
      //  int rewardGems = GetRandomNumber(chestController.chestModel.Gems.x, chestController.ChestModel.Gems.y);
      //  int rewardCoins = GetRandomNumber(chestController.ChestModel.Coins.x, chestController.ChestModel.Coins.y);
        ChestSlotController selectedSlot = System.Array.Find<ChestSlotController>(chestSlotControllers, slot => slot.GetChestController() == chestController);
        eventService.OnAddingCoinsAndGems.Invoke(20, 20);
        eventService.ShowRewardsPanel.Invoke(20, 20);
        selectedSlot.RemoveChest();
        Debug.Log("Rewards unclock");
    }
    private void UnlockChest()
    {
        if (currentChestController != null)
        {
            eventService.OnRemovingGems.Invoke(Mathf.CeilToInt(currentChestController.chestModel.CurrentUnlockTime / 600));
            currentChestController.ChangeChestState(ChestStates.UNLOCKED);
        }
    }
    private void OnTimerButtonClick()
    {
        if (currentChestController != null)
            eventService.EnqueueChest.Invoke(currentChestController);
    }
    ~ChestService()
    {
        UnRegisterEventListener();
    }

}
