using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChestUIManager : MonoBehaviour
{
    [SerializeField] private int coins;
    [SerializeField] private int gems;
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI gemsText;
    [SerializeField] private Button generateChestButton;
    [SerializeField] private ChestSO chestSO;
    [SerializeField] private ChestView chestView;

    [Header("ChestSlots")]
    [SerializeField] ChestSlotView[] chestSlots;
    

    //scripts

    private ChestService chestService;
    private EventService eventService;

    private void Start()
    {
        InitAllChestUIElements();
    }

    private void InitAllChestUIElements()
    {
      
        eventService = new EventService();
        chestService = new ChestService(chestSlots, chestSO, chestView, eventService);

        generateChestButton.onClick.AddListener(OnGenerateButtonClick);
    }
    private void OnGenerateButtonClick()
    {
        eventService.OnGenerateButtonPressed.Invoke();
        Debug.Log("invoked Ongeneratepress");
    }


}
