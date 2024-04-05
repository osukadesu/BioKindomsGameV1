using UnityEngine;
using UnityEngine.UI;
public class ItemSlotV2 : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] Image imgItem;
    public void Set(InventoryItem item)
    {
        textName.text = item.inventoryItemDataV2.itemName;
        imgItem.sprite = item.inventoryItemDataV2.imgItem;
    }
}