public class ItemObjectA3 : ItemObjectTemplate
{
    protected internal override void OnHandlePickUp()
    {
        textMessage = referenceItem.itemName + " Guardado!";
        textGralController.StartingAT2(textMessage);
        InventorySystemA3.instance3.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
        textCount.numItem++;
        textCount.myTextCount[2].text = textCount.numItem + "/5";
    }
    protected internal override void OnHandlePickUpLoad()
    {
        DisableCollider();
        InventorySystemA3.instance3.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
}