using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ChestSlotView : MonoBehaviour, IPointerClickHandler
{
   [SerializeField] public Image chestImage;
    private bool hasChest = false;

    public bool IsOccupied()
    {
        return hasChest;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked on the empty slot ");
    }
}
