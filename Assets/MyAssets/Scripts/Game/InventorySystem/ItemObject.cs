using UnityEngine;
public class ItemObject : MonoBehaviour
{
    [SerializeField] protected InventoryItemDataV2 referenceItem;
    [SerializeField] protected ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] protected bool item, isNextLevel;
    [SerializeField] protected TextGralController textGralController;
    protected string textMessage;
    public bool IsNextLevel { get => isNextLevel; set => isNextLevel = value; }
    void Awake()
    {
        AwakeCharge();
        textGralController = FindObjectOfType<TextGralController>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
    }
    void Update()
    {
        PickupKeydown();
    }
    void AwakeCharge()
    {
        referenceItem.itemIsCheck = false;
        item = false;
    }
    void DisableCollider()
    {
        gameObject.SetActive(false);
    }
    void PickupKeydown()
    {
        if (item && Input.GetKeyDown(KeyCode.E))
        {
            OnHandlePickUp();
            isNextLevel = true;
            showLevelCaseV2.pedestalAnim.SetBool("pedestalShow", false);
        }
        else
        {
            referenceItem.itemIsCheck = false;
            isNextLevel = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textMessage = "Presiona E para guardar " + "( " + referenceItem.itemName + " )";
            textGralController.ShowText(textMessage);
            item = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textGralController.HideText();
            item = false;
        }
    }
    void OnHandlePickUp()
    {
        textMessage = referenceItem.itemName + " Guardado!";
        textGralController.StartingAT2(textMessage);
        InventorySystem.inventorySystem.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
    public void OnHandlePickUpLoad()
    {
        DisableCollider();
        InventorySystem.inventorySystem.Add(referenceItem);
        referenceItem.itemIsCheck = true;
        Destroy(this.gameObject);
    }
}