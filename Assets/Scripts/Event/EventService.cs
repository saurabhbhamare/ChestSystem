using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventService 
{
    public EventController OnGenerateButtonPressed;
    public EventController<ChestController> OnChestClick;
    public EventController<int, int> OnAddingCoinsAndGems;
    public EventController<int> OnRemovingGems;
    public EventController<int> SetGemsButtonAmount;
    public EventController<string> SetTimeButtonText;
    public EventController OnGemsButtonClick;
    public EventController OnTimeButtonClick;
    public EventController<string, string> ShowNotificationBox;
    public EventController<string, string> ShowLockedStateNotificationBox;
    public EventController<string, string> ShowUnlockingStateNotificationBox;
    public EventController<int, int> ShowRewardsPanel;
    public EventController<ChestController> EnqueueChest;
    public EventController DequeueChest;
    public EventService()
    {
        OnGenerateButtonPressed = new EventController();
        OnChestClick = new EventController<ChestController>();
        OnAddingCoinsAndGems = new EventController<int, int>();
        OnRemovingGems = new EventController<int>();
        SetGemsButtonAmount = new EventController<int>();
        SetTimeButtonText = new EventController<string>();
        OnGemsButtonClick = new EventController();
        OnTimeButtonClick = new EventController();
        ShowNotificationBox = new EventController<string, string>();
        ShowLockedStateNotificationBox = new EventController<string, string>();
        ShowUnlockingStateNotificationBox = new EventController<string, string>();
        ShowRewardsPanel = new EventController<int, int>();
        EnqueueChest = new EventController<ChestController>();
        DequeueChest = new EventController();
    }
}
