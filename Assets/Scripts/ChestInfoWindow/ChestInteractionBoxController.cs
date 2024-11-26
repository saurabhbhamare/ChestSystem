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
        eventService.ShowNotificationBox.AddListener(ShowInteractionBox);
        eventService.ShowLockedStateNotificationBox.AddListener(ShowLockedStateNotificationBox);
        eventService.ShowUnlockingStateNotificationBox.AddListener(ShowUnlockingStateNotificationBox);
        eventService.OnGemsButtonClick.AddListener(DisableNotificationView);
        eventService.OnTimeButtonClick.AddListener(DisableNotificationView);
        eventService.ShowRewardsPanel.AddListener(ShowRewardsBox);
    }
    private void ShowInteractionBox(string title,string message)
    {

        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetMessageBoxActive(true);
        chestInteractionBoxView.SetNotificationTitle(title);
        chestInteractionBoxView.SetNotificationMessage(message);
        chestInteractionBoxView.SetRewardsPanelActive(false);
        chestInteractionBoxView.DisableButtons();

    }
    private void ShowLockedStateNotificationBox(string title, string message)
    {
        chestInteractionBoxView.DisableButtons();
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetMessageBoxActive(true);
        chestInteractionBoxView.SetNotificationTitle(title);
        chestInteractionBoxView.SetNotificationMessage(message);
        chestInteractionBoxView.SetRewardsPanelActive(false);
        chestInteractionBoxView.EnableGemsButton();
        chestInteractionBoxView.EnableTimeButton();
    }

    private void ShowUnlockingStateNotificationBox(string title, string message)
    {
        chestInteractionBoxView.DisableButtons();
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetMessageBoxActive(true);
        chestInteractionBoxView.SetNotificationTitle(title);
        chestInteractionBoxView.SetNotificationMessage(message);
        chestInteractionBoxView.SetRewardsPanelActive(false);
        chestInteractionBoxView.EnableGemsButton();
    }

    private void ShowRewardsBox(int coinsAmount, int gemsAmount)
    {
        chestInteractionBoxView.gameObject.SetActive(true);
        chestInteractionBoxView.SetRewardsPanelActive(true);
        chestInteractionBoxView.SetMessageBoxActive(false);
        chestInteractionBoxView.SetNotificationTitle("You Received");
        chestInteractionBoxView.SetRewardCoinsText(coinsAmount);
        chestInteractionBoxView.SetRewardGemsText(gemsAmount);
        chestInteractionBoxView.DisableButtons();
    }

    public void DisableNotificationView() => chestInteractionBoxView.gameObject.SetActive(false);

    private void UnsubscribeEvents()
    {
        eventService.ShowNotificationBox.RemoveListener(ShowInteractionBox);
        eventService.ShowLockedStateNotificationBox.RemoveListener(ShowLockedStateNotificationBox);
        eventService.ShowUnlockingStateNotificationBox.RemoveListener(ShowUnlockingStateNotificationBox);
        eventService.OnGemsButtonClick.RemoveListener(DisableNotificationView);
        eventService.OnTimeButtonClick.RemoveListener(DisableNotificationView);
        eventService.ShowRewardsPanel.RemoveListener(ShowRewardsBox);
    }

    ~ChestInteractionBoxController()
    {
        UnsubscribeEvents();
    }
}
