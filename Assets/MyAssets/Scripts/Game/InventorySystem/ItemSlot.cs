using UnityEngine;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] Image imageShadowTicket, imageTicket, imageShadowItem, imageItem;
    public void Set(InventoryItem item)
    {
        textName.text = item.inventoryItemData.itemName;
        imageShadowTicket.sprite = item.inventoryItemData.imageShadowTicket;
        imageTicket.sprite = item.inventoryItemData.imageTicket;
        imageShadowItem.sprite = item.inventoryItemData.imageShadowItem;
        imageItem.sprite = item.inventoryItemData.imageItem;
    }
}