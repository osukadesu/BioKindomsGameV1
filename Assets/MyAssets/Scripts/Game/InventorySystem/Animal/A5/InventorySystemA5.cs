using System.Collections.Generic;
using UnityEngine;
public class InventorySystemA5 : MonoBehaviour
{
    public static InventorySystemA5 instance5;
    public delegate void onInventoryChangedEvent();
    public event onInventoryChangedEvent OnInventoryChangedEventCallBack;
    public Dictionary<InventoryItemData, InventoryItem> _itemDictionary;
    public List<InventoryItem> inventoryItems;
    void Awake()
    {
        inventoryItems = new List<InventoryItem>();
        _itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
        instance5 = this;
    }
    public void Add(InventoryItemData referenceData)
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