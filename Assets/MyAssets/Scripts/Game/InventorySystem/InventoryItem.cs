[System.Serializable]
public class InventoryItem
{
    public InventoryItemData inventoryItemData;
    public int stackSize;
    public InventoryItem(InventoryItemData itemData)
    {
        inventoryItemData = itemData;
        AddStack();
    }
    public void AddStack()
    {
        stackSize++;
    }
}