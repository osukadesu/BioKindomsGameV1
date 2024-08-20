using System.Collections.Generic;
using UnityEngine;
public class InventorySystem : MonoBehaviour
{
    public static InventorySystem inventorySystem;
    public Dictionary<InventoryItemDataV2, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventoryItems;
    void Awake()
    {
        inventorySystem = this;
        inventoryItems = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemDataV2, InventoryItem>();
    }
    public void Add(InventoryItemDataV2 referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddStack();
        }
        else
        {
            InventoryItem newItem = new(referenceData);
            inventoryItems.Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
        }
    }
}