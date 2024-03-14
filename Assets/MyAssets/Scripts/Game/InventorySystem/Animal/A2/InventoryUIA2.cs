public class InventoryUIA2 : InventoryUITemplate
{
    protected internal override void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystemA2.instance2.inventoryItems)
        {
            AddInventorySlot(item);
        }
    }
}