using UnityEngine;
public class OpenDoorV1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemA;
    [SerializeField] Animator openDoorAnim;
    bool canOpen;
    void Update()
    {
        for (int i = 0; i < referenceItemA.Length; i++)
        {
            if (referenceItemA[i].itemIsCheck)
            {
                canOpen = true;
            }
            else
            {
                canOpen = false;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canOpen)
        {
            openDoorAnim.SetBool("openDoor", true);
        }
        else
        {
            openDoorMessage.SetMessage();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openDoorAnim.SetBool("openDoor", false);
        }
    }
}