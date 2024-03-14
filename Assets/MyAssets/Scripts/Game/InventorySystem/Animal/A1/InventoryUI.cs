public class InventoryUI : InventoryUITemplate
{
    protected internal override void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystem.instance.inventoryItems)
        {
            AddInventorySlot(item);
        }
    }
}