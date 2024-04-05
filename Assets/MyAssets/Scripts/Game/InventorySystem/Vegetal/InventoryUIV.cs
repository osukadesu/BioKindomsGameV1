public class InventoryUIV : InventoryUITemplate
{
    protected internal override void DrawInventory()
    {
        foreach (InventoryItem item in InventorySystemV.instance2.inventoryItems)
        {
            AddInventorySlot(item);
        }
    }
}