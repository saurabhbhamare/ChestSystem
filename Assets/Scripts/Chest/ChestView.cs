
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ChestView : MonoBehaviour
{
    [SerializeField] private Image chestImage;
    [SerializeField] private TextMeshProUGUI chestName;
    [SerializeField] private TextMeshProUGUI chestStatus;

    private ChestController chestController;

    public void SetChestImage(Sprite chestSprite) => this.chestImage.sprite = chestSprite;
   
    public void SetChestController(ChestController chestController)=> this.chestController = chestController;
   
    public void SetChestName(string chestName) => this.chestName.text = chestName;
 
    public void SetChestStatus(string status) => chestStatus.text = status;
   
}