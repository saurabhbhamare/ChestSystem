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
        // eventService.OnChestClick.AddListener(ShowLockedStateNotificationPanel);
        eventService.OnLockedChestClicked.AddListener(ShowLockedStateNotificationPanel);
        eventService.OnUnlockingChestClicked.AddListener(ShowUnlockingStateNotificationPanel);
    }
    public void ShowLockedStateNotificationPanel(ChestController chestController)
    {
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.EnableTimeButton();
        chestInteractionBoxView.SetTimeButtonText(chestController.chestModel.UnlockTime.ToString()+" Seconds");
        chestInteractionBoxView.SetNotificationTitle(chestController.chestModel.ChestType.ToString());
        chestInteractionBoxView.SetGemsButtonText(chestController.chestModel.GemsAmoundToOpen);
        
        //Debug.Log("CHEST IS IN  " + chestController.GetChestState().ToString());
       // chestInteractionBoxView.SetGemsButtonText(chestController.g)
       
    }
    public void ShowUnlockingStateNotificationPanel(ChestController chestController)
    {
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetGemsButtonText(chestController.chestModel.GemsAmoundToOpen);
        chestInteractionBoxView.DisableTimeButton();
        //chestController.ChangeChestState(ChestStates.UNLOCKED);
        
    }
    public void ShowUnlockedStateNotification()
    { 

    }
    public void ShowqueuedStateNotification()
    {

    }
    public void OnTimeButtonClick()
    {

    }
    public void DisableNotificationPanel() => chestInteractionBoxView.gameObject.SetActive(false);
}
