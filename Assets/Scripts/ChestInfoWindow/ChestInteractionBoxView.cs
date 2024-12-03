using TMPro;
using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ChestInteractionBoxView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI notificationMsg;

    [SerializeField] private TextMeshProUGUI notificationTitle;


    [Header("Buttons")]
    [SerializeField] private Button notificationCloseButton;
    [SerializeField] private Button notificationGemsButton;
    [SerializeField] private TextMeshProUGUI notificationGemsButtonText;
    [SerializeField] private Button notificationTimeButton;
    [SerializeField] private TextMeshProUGUI notificationTimeButtonText;
    [Header("Rewards Section")]
    [SerializeField] private GameObject rewardsPanel;
    [SerializeField] private TextMeshProUGUI rewardGemsText;
    [SerializeField] private TextMeshProUGUI rewardCoinsText;

    private EventService eventService;
    private ChestInteractionBoxController chestInteractionBoxController;
    private void OnEnable()
    {
        RegisterEventListenersForButtons();
        notificationCloseButton.onClick.AddListener(OnClosePanelClick);
    }
    public void Init(EventService eventService, ChestInteractionBoxController chestInteractionBoxController)
    {
        this.eventService = eventService;
        this.chestInteractionBoxController = chestInteractionBoxController;
    }
    private void RegisterEventListenersForButtons()
    {
        notificationTimeButton.onClick.AddListener(OnTimeButtonClick);
        notificationGemsButton.onClick.AddListener(OnGemsButtonClick);
    }
    private void OnTimeButtonClick()
    {
        eventService.OnTimeUnlockButtonClicked.Invoke();
        chestInteractionBoxController.DisableNotificationPanel();
    }
    private void OnGemsButtonClick()
    {
        eventService.OnGemsButtonClicked.Invoke();
        chestInteractionBoxController.DisableNotificationPanel();
    }
    public void SetNotificationTitle(string title) => this.notificationTitle.text = title;
    public void SetGemsButtonText(string amount) => this.notificationGemsButtonText.text = amount.ToString();
    public void SetTimeButtonText(string time) => this.notificationTimeButtonText.text = time;
    public void EnableTimeButton() => notificationTimeButton.gameObject.SetActive(true);
    public void SetRewardsPanelActive() => rewardsPanel.SetActive(true);
    public void DisableTimeButton()
    {
        notificationTimeButton.gameObject.SetActive(false);
    }
    private void OnClosePanelClick()
    {
        chestInteractionBoxController.DisableNotificationPanel();
    }
}
