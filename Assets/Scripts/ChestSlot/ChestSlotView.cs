using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
public class ChestSlotView : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] public Image chestImage;
    [SerializeField] private TextMeshProUGUI chestSlotStatusText;
    private ChestSlotController chestSlotController;
    public void SetChestSlotController(ChestSlotController chestSlotController)
    {
        this.chestSlotController = chestSlotController;
    }
    public ChestSlotController GetChestSlotController() => chestSlotController;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (chestSlotController == null) { return; }
        else
        {
            chestSlotController.OnChestClick();
        }
    }
}
