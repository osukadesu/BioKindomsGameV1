using UnityEngine;
public abstract class InventoryUITemplate : MonoBehaviour
{
    [SerializeField] protected GameObject itemSlotPrefab;
    protected internal void OnUpdateInventory()
    {
        foreach (Transform t in transform)
        {
            Destroy(t.transform.gameObject);
        }
        DrawInventory();
    }
    protected internal abstract void DrawInventory();
    protected void AddInventorySlot(InventoryItem item)
    {
        GameObject obj = Instantiate(itemSlotPrefab);
        obj.transform.SetParent(transform, false);
        ItemSlotV2 slot = obj.GetComponent<ItemSlotV2>();
        slot.Set(item);
    }
}