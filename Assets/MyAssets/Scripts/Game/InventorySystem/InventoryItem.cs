[System.Serializable]
public class InventoryItem
{
    public InventoryItemDataV2 inventoryItemDataV2;
    public int stackSize;
    public InventoryItem(InventoryItemDataV2 itemData)
    {
        inventoryItemDataV2 = itemData;
        AddStack();
    }
    public void AddStack()
    {
        stackSize++;
    }
}