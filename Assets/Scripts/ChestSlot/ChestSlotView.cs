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
    public ChestSlotController GetChestSlotController()
    {
        return chestSlotController;
    }
    public bool IsOccupied()
    {
        return hasChest;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked on the empty slot ");

        if (!chestSlotController.IsChestSlotEmpty())
            chestSlotController.OnChestClick(chestSlotController.GetChestController());
    }
    public void SetChestSlotStatusText(string statusText)
    {
        chestSlotStatusText.text = statusText;
    }
    
}
