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
    private Queue<ChestController> chestUnlockQueue;
    private int queueCount = 2;

    public ChestService(ChestSlotView[] chestSlots, ChestSO chestSO, ChestView chestView, EventService eventService)
    {
        this.chestSlots = chestSlots;
        this.chestView = chestView;
        this.chestSO = chestSO;
        this.eventService = eventService;
        chestSlotControllers = new ChestSlotController[chestSlots.Length];
        chestControllerQueue = new Queue<ChestController>();
        for (int i = 0; i < chestSlots.Length; i++)
        {
            chestSlotControllers[i] = new ChestSlotController(chestSlots[i], eventService);

            Debug.Log("created slot controllers for every slot ");
        }
        RegisterEventListeners();
        Debug.Log("Length of chest slot controllers" + chestSlotControllers.Length);
    }
    private void RegisterEventListeners()
    {
        eventService.OnGenerateButtonPressed.AddListener(GenerateNewChest);
        eventService.OnChestClick.AddListener(HandleChestClick);
        eventService.OnTimeUnlockButtonClicked.AddListener(UnlockWithTimer);
        eventService.OnGemsButtonClicked.AddListener(HandleUnlockWithGems);
    }
    private void GenerateNewChest()
    {
        ChestSlotController emptySlot = GetEmptyChestSlot();

        if (emptySlot != null)
        {
            ChestController chestController = new ChestController(GetRandomChestData(), chestView, emptySlot.GetChestTransformParent(), eventService, emptySlot);
            emptySlot.SetChestController(chestController); 
        }
        else { Debug.Log("slot not available"); }
    }
    private ChestSlotController GetEmptyChestSlot()
    {
        foreach (var slot in chestSlotControllers)
        {
            if (slot.IsChestSlotEmpty())
            {   return slot; }
        }
        return null;
    }
    public ChestData GetRandomChestData() => chestSO.chests[Random.Range(0, chestSO.chests.Length)];
    private void UnRegisterEventListener()=> eventService.OnGenerateButtonPressed.RemoveListener(GenerateNewChest);
    private void HandleChestClick(ChestController chestController)
    {
        currentChestController = chestController;
        Debug.Log("Current clicked Chest Controller chest State" + currentChestController.GetChestState().ToString());
        if (chestController.GetChestState() == ChestStates.LOCKED)
        {
            eventService.OnLockedChestClicked.Invoke(chestController);
        }
        else if (chestController.GetChestState() == ChestStates.QUEUED)
        {
            //  eventService.OnQueuedChestClicked.Invoke();
            Debug.Log("Chest is in Queued State");
        }
        else if (chestController.GetChestState() == ChestStates.UNLOCKING)
        {
            eventService.OnUnlockingChestClicked.Invoke(chestController);
            Debug.Log("Chest is in Unlocking State");
        }
        else if (chestController.GetChestState() == ChestStates.UNLOCKED)
        {
            GenerateRewards();
            eventService.OnRemovingChest.Invoke(chestController);
            GameObject.Destroy(chestController.chestView.gameObject);
            chestController.GetChestSlotController().SetChestSlotState(ChestSlotState.EMPTY);
        }
    }
    private int GetQueueCount() => chestControllerQueue.Count;
    private void UnlockWithTimer() => currentChestController.ChangeChestState(ChestStates.UNLOCKING);
    private void HandleUnlockWithGems()
    {
        Debug.Log("Running handle ulock with gems");
        if (currentChestController != null)
        {
            int gemsRequired = currentChestController.chestModel.GemsAmoundToOpen;
            Debug.Log("Required gems are" + gemsRequired);
            eventService.OnCheckGemBalance.Invoke(gemsRequired, hasEnoughGems =>
            {
                Debug.Log("OnCheckGemBalance inside");
                if (hasEnoughGems)
                {
                    Debug.Log("inside hasEnoughGems");
                    eventService.OnDeductGems.Invoke(gemsRequired);
                    Debug.Log("Unlocked with gems in HandleUnlockWithGems");
                    currentChestController.ChangeChestState(ChestStates.UNLOCKED);
                }
                else
                {
                    Debug.Log("Not enough gems to unlock the chest!");
                }
            });
        }
    }
    private void GenerateRewards()
    {
        int rewardedCoins = 0;
        int rewardedGems = 0;

        switch (currentChestController.chestModel.ChestType)
        {
            case ChestType.COMMON:
                rewardedCoins = Random.Range(50, 100);
                rewardedGems = Random.Range(5, 20);
                break;
            case ChestType.RARE:
                rewardedCoins = Random.Range(100, 200);
                rewardedGems = Random.Range(20, 50);
                break;
            case ChestType.EPIC:
                rewardedCoins = Random.Range(200, 400);
                rewardedGems = Random.Range(50, 100);
                break;
            case ChestType.LEGENDARY:
                rewardedCoins = Random.Range(400, 800);
                rewardedGems = Random.Range(100, 200);
                break;
            default:
                Debug.LogWarning("Unknown chest type");
                break;
        }
        eventService.OnGenerateRewards.Invoke(rewardedCoins, rewardedGems);
    }
    ~ChestService()
    {
        UnRegisterEventListener();
    }
}
