using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class ItemObject : MonoBehaviour
{
    [SerializeField] InventoryItemDataV2 referenceItem;
    [SerializeField] LevelDisplay levelDisplay;
    [SerializeField] Animator txtAnim, txtAnim2;
    [SerializeField] Text textGral, textGral2;
    [SerializeField] bool item, isNextLevel;
    string textMessage;
    public bool IsNextLevel { get => isNextLevel; set => isNextLevel = value; }
    void Awake()
    {
        AwakeCharge();
        levelDisplay = FindObjectOfType<LevelDisplay>();
    }
    void Update()
    {
        PickupKeydown();
        SaveMessage();
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
            levelDisplay.pedestalAnim.SetBool("pedestalShow", false);
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
            ShowText(textMessage);
            item = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HideText();
            item = false;
        }
    }
    void OnHandlePickUp()
    {
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
    void ShowText(string message)
    {
        textGral.text = message;
        txtAnim.SetBool("uiInteraction", true);
    }
    void HideText()
    {
        textGral.text = "";
        txtAnim.SetBool("uiInteraction", false);
    }
    void ShowTextV2(string message)
    {
        textGral2.text = message;
        txtAnim2.SetBool("uiMessage", true);
    }
    IEnumerator HideTextV2()
    {
        yield return new WaitForSeconds(1f);
        textGral2.text = "";
        txtAnim2.SetBool("uiMessage", false);
    }
    void SaveMessage()
    {
        if (levelDisplay.BoolNextLevel())
        {
            textMessage = referenceItem.itemName + " Guardado!";
            ShowTextV2(textMessage);
            StartCoroutine(HideTextV2());
        }
    }
}