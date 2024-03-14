using UnityEngine;
public abstract class ItemObjectTemplate : MonoBehaviour
{
    [SerializeField] protected LevelSystem levelSystem;
    [SerializeField] protected InventoryItemData referenceItem;
    [SerializeField] protected bool item, isNextLevel;
    [SerializeField] protected TextGralController textGralController;
    [SerializeField] protected TextCount textCount;
    protected string textMessage;
    public bool IsNextLevel { get => isNextLevel; set => isNextLevel = value; }

    void Awake()
    {
        AwakeCharge();
        textGralController = FindObjectOfType<TextGralController>();
        textCount = FindObjectOfType<TextCount>();
        levelSystem = FindObjectOfType<LevelSystem>();
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
    protected void DisableCollider()
    {
        gameObject.SetActive(false);
    }
    void PickupKeydown()
    {
        if (item && Input.GetKeyDown(KeyCode.E))
        {
            OnHandlePickUp();
            isNextLevel = true;
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
            textMessage = "Presiona E para recoger " + "( " + referenceItem.itemName + " )";
            textGralController.ShowText(textMessage);
            item = true;
            Debug.Log("In Enter");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            textGralController.HideText();
            item = false;
            Debug.Log("In Exit");
        }
    }
    protected internal abstract void OnHandlePickUp();
    protected internal abstract void OnHandlePickUpLoad();
}
