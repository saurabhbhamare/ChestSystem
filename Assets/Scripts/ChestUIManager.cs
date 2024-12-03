using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class ChestUIManager : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private int gems;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private Button generateChestButton;
    [SerializeField] private ChestSO chestSO;
    [SerializeField] private ChestView chestView;
    [SerializeField] private ChestInteractionBoxView chestInteractionBoxView;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private GameObject messageBox;
    //  [SerializeField] private GameObject msgBox;
    [SerializeField] private int queueCount;

    [Header("ChestSlots")]
    [SerializeField] ChestSlotView[] chestSlots;
    //scripts

    private ChestInteractionBoxController chestInteractionBoxController;
    private ChestService chestService;
    private EventService eventService;


  //  private UserInteractionService;
    private void Start()
    {
        InitAllChestUIElements();
    } 
 
    private void InitAllChestUIElements()
    {
        coinsText.text = coins.ToString();
        gemsText.text = gems.ToString();
        eventService = new EventService();
        chestInteractionBoxController = new ChestInteractionBoxController(eventService,chestInteractionBoxView);
        chestService = new ChestService(chestSlots, chestSO, chestView, eventService);
        RegisterEventListeners();
    }
    private void OnGenerateButtonClick()
    {
        eventService.OnGenerateButtonPressed.Invoke();
        Debug.Log("invoked Ongeneratepress");
    }
    private void RegisterEventListeners()
    {
        generateChestButton.onClick.AddListener(OnGenerateButtonClick);
        eventService.OnDeductGems.AddListener(DeductGems);
        eventService.OnCheckGemBalance.AddListener(CheckGemBalance);
        eventService.OnGenerateRewards.AddListener(AddRewards);
        eventService.OnGenerateRewards.AddListener(SetRewardsMessage);
    }
    private void OnDisable()
    {
        
    }
    private void CheckGemBalance(int requiredGems, Action<bool> responseCallback)
    { 
        bool hasEnoughGems = gems >= requiredGems; 
        Debug.Log($"Checking if player has enough gems: {gems} available, {requiredGems} required"); responseCallback.Invoke(hasEnoughGems); 
    }
    private void DeductGems(int amount)
    {
        gems -= amount;
        gemsText.text = gems.ToString();
    }
    private void UpdateGems(int newGemCount)
    {
        gems = newGemCount; 
        gemsText.text = gems.ToString();
    }
    private void AddRewards(int coins , int gems)
    {
        this.coins += coins;
        this.gems += gems;
        UpdateCoinsText(); 
        UpdateGemsText();
    }
    public void SetRewardsMessage(int coins, int gems)
    {
        messageBox.SetActive(true);
        messageText.text = ("You have recieved  " + coins + " Coins " + " and " + gems + " Gems");
        StartCoroutine(HideNotificationAfterDelay(4f));

    }
    private IEnumerator HideNotificationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); messageBox.SetActive(false);
    }

    private void UpdateCoinsText() { coinsText.text = coins.ToString(); }
    private void UpdateGemsText() { gemsText.text = gems.ToString(); }
}
