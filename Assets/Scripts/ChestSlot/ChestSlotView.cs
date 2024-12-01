using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ChestSlotView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Image chestImage;
    [SerializeField] private TextMeshProUGUI chestSlotStatusText;
    private bool hasChest = false;
    private ChestSlotController chestSlotController; 
    public void SetChestSlotController(ChestSlotController chestSlotController)
    {
        this.chestSlotController = chestSlotController;
    }
    public ChestSlotController GetChestSlotController() => chestSlotController;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked on the empty slot ");
        chestSlotController.OnChestClick(); 
    }
    public void SetChestSlotStatusText(string statusText)
    {
        chestSlotStatusText.text = statusText;
    }   
}
