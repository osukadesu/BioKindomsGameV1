public class ItemObject : ItemObjectTemplate
{
    protected internal override void OnHandlePickUp()
    {
        textMessage = referenceItem.itemName + " Guardado!";
        textGralController.StartingAT2(textMessage);
        InventorySystem.instance.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
    protected internal override void OnHandlePickUpLoad()
    {
        DisableCollider();
        InventorySystem.instance.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
}