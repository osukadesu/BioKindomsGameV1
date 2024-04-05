public class ItemObjectA2 : ItemObjectTemplate
{
    protected internal override void OnHandlePickUp()
    {
        textMessage = referenceItem.itemName + " Guardado!";
        textGralController.StartingAT2(textMessage);
        //InventorySystemV.instance2.Add(referenceItem);
        //referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
        //textCount.numItem++;
        //textCount.myTextCount[1].text = textCount.numItem + "/5";
    }
    protected internal override void OnHandlePickUpLoad()
    {
        DisableCollider();
        //InventorySystemV.instance2.Add(referenceItem);
        //referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
}