using UnityEngine;
[CreateAssetMenu(fileName = "Inventory Item Data V2", menuName = "Inventory Item Data V2", order = 0)]
[System.Serializable]
public class InventoryItemDataV2 : ScriptableObject
{
    public string itemName;
    public Sprite imgItem;
    public bool itemIsCheck;
}