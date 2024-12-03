using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
public class EventService
{
    public EventController OnGenerateButtonPressed;
    public EventController<ChestController> OnChestClick;
    public EventController OnTimeUnlockButtonClicked;
    public EventController<int> SetGemsButtonAmount;
    public EventController<ChestController> OnLockedChestClicked;
    public EventController OnQueuedChestClicked;
    public EventController<ChestController> OnUnlockingChestClicked;
    public EventController OnUnlockedChestClicked;
    public EventController<int, Action<bool>> OnCheckGemBalance;
    public EventController<int> OnDeductGems;
    public EventController OnGemsButtonClicked;
    public EventController<ChestController> OnRemovingChest;
    public EventController<ChestController> OnChestUnlockFinished;
    public EventController<int, int> OnGenerateRewards;
    public EventService()
    {
        OnGenerateButtonPressed = new EventController();
        OnChestClick = new EventController<ChestController>();
        SetGemsButtonAmount = new EventController<int>();
        OnLockedChestClicked = new EventController<ChestController>();
        OnTimeUnlockButtonClicked = new EventController();
        OnCheckGemBalance = new EventController<int, Action<bool>>();
        OnDeductGems = new EventController<int>();
        OnGemsButtonClicked = new EventController();
        OnGenerateRewards = new EventController<int, int>();
        OnUnlockedChestClicked = new EventController();
        OnRemovingChest = new EventController<ChestController>();
        OnUnlockingChestClicked = new EventController<ChestController>();
        OnChestUnlockFinished = new EventController<ChestController>();
    }
}
