using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteractionBoxController 
{
    private EventService eventService;
    private ChestInteractionBoxView chestInteractionBoxView;

    public ChestInteractionBoxController(EventService eventService, ChestInteractionBoxView chestInteractionBoxView)
    {
        this.eventService = eventService;
        this.chestInteractionBoxView = chestInteractionBoxView;
        this.chestInteractionBoxView.Init(eventService, this); 
        RegisterEventListeners();
    }
    private void RegisterEventListeners()
    {
        eventService.OnLockedChestClicked.AddListener(ShowLockedStateNotificationPanel);
        eventService.OnUnlockingChestClicked.AddListener(ShowUnlockingStateNotificationPanel);
        eventService.OnUnlockedChestClicked.AddListener(ShowUnlockedStateNotification);
    }
    public void ShowLockedStateNotificationPanel(ChestController chestController)
    {
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.EnableTimeButton();
        chestInteractionBoxView.SetTimeButtonText(chestController.chestModel.UnlockTime.ToString()+" Seconds");
        chestInteractionBoxView.SetNotificationTitle(chestController.chestModel.ChestType.ToString());
        chestInteractionBoxView.SetGemsButtonText(chestController.chestModel.GemsAmoundToOpen.ToString()+" Gems");
    }
    public void ShowUnlockingStateNotificationPanel(ChestController chestController)
    {
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetGemsButtonText(chestController.chestModel.GemsAmoundToOpen.ToString()+"Gems");
        chestInteractionBoxView.DisableTimeButton(); 
    }
    public void ShowUnlockedStateNotification()
    {
        chestInteractionBoxView.SetRewardsPanelActive();
    }
    public void DisableNotificationPanel() => chestInteractionBoxView.gameObject.SetActive(false);
}
