using System.Collections.Generic;
using UnityEngine;
public class InventorySystemV : MonoBehaviour
{
    public static InventorySystemV instance2;
    public delegate void onInventoryChangedEvent();
    public event onInventoryChangedEvent OnInventoryChangedEventCallBack;
    public Dictionary<InventoryItemDataV2, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventoryItems;
    void Awake()
    {
        inventoryItems = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemDataV2, InventoryItem>();
        instance2 = this;
    }
    public void Add(InventoryItemDataV2 referenceData)
    {
        if (_itemDictionary.TryGetValue(referenceData, out InventoryItem value))
        {
            value.AddStack();
            OnInventoryChangedEventCallBack.Invoke();
        }
        else
        {
            InventoryItem newItem = new(referenceData);
            inventoryItems.Add(newItem);
            _itemDictionary.Add(referenceData, newItem);
            OnInventoryChangedEventCallBack.Invoke();
        }
    }
}