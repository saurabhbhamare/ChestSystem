using TMPro;
using UnityEngine.UI;
using UnityEngine;

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
        RegisterEventListeners();
        //OnButtonClick();

        notificationCloseButton.onClick.AddListener(OnClosePanelClick);
      //  notificationTimeButton.onClick.AddListener(OnTimeButtonClick);
        //notificationCloseButton.onClick.AddListener();
    }
    public void Init(EventService eventService, ChestInteractionBoxController chestInteractionBoxController)
    {
        this.eventService = eventService;
        this.chestInteractionBoxController = chestInteractionBoxController;

    }
    private void RegisterEventListeners()
    {
        if(eventService == null)
        {
            Debug.Log("event service is null");
        }
        //eventService.SetGemsButtonAmount.AddListener(SetGemsButtonText);
        // eventService.SetTimeButtonText.AddListener(SetTimeButtonText);
        notificationTimeButton.onClick.AddListener(OnTimeButtonClick);
        notificationGemsButton.onClick.AddListener(OnGemsButtonClick);
      //  eventService.OnGemsButtonClicked.AddListener()
    }
    private void OnButtonClick()
    {
       // notificationCloseButton.onClick.AddListener(OnNotificationCloseButtonClick);
      //  notificationCloseButton.onClick.AddListener(OnGemsButtonClick);
       // notificationCloseButton.onClick.AddListener(OnTimeButtonClick);
       
    }
    private void OnTimeButtonClick()
    {
        eventService.OnTimeUnlockButtonClicked.Invoke();
        chestInteractionBoxController.DisableNotificationPanel();

    }
    private void OnGemsButtonClick()
    {
        Debug.Log("clicked on the gems button");
        eventService.OnGemsButtonClicked.Invoke();
        chestInteractionBoxController.DisableNotificationPanel();
        //chestInteractionBoxController.DisableNotificationPanel();
    }
    public void SetNotificationTitle(string title) => this.notificationTitle.text = title;
    public void SetNotificationMessage(string message) => this.notificationMsg.text = message;
    public void   SetMessageBoxActive(bool status) => notificationMsg.gameObject.SetActive(status);
    
    //buttons
    public void SetGemsButtonText(int amount)=> this.notificationGemsButtonText.text = amount.ToString();
    public void SetTimeButtonText(string time) => this.notificationTimeButtonText.text = time;
   // private void OnNotificationCloseButtonClick() => chestInteractionBoxController.DisableNotificationView();
    //private void OnGemsButtonClick() => eventService.OnGemsButtonClick.Invoke();
    
    public void EnableGemsButton() => notificationGemsButton.gameObject.SetActive(true);
    public void EnableTimeButton() => notificationTimeButton.gameObject.SetActive(true);

    //rewards
    public void SetRewardsPanelActive(bool status) => rewardsPanel.SetActive(status);
    public void SetRewardGemsText(int amount) => rewardGemsText.text = amount.ToString();
    public void SetRewardCoinsText(int amount) => rewardCoinsText.text = amount.ToString();

    public void DisableTimeButton()
    {
       // notificationGemsButton.gameObject.SetActive(false);
        notificationTimeButton.gameObject.SetActive(false);
    }
    private void UnRegisterEventListeners()
    {
        //eventService.SetGemsButtonAmount.RemoveListener(SetGemsButtonText);
       // eventService.SetTimeButtonText.RemoveListener(SetTimeButtonText);
       // notificationCloseButton.onClick.RemoveListener(OnNotificationCloseButtonClick);
        notificationGemsButton.onClick.RemoveListener(OnGemsButtonClick);
      //  notificationTimeButton.onClick.RemoveListener(OnTimeButtonClick);
    }
    private void OnClosePanelClick()
    {
        chestInteractionBoxController.DisableNotificationPanel();
    }
    private void OnDisable()
    {
        UnRegisterEventListeners(); 
    }

}
