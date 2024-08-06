using UnityEngine;
public class OpenDoorV1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemA;
    [SerializeField] Animator openDoorAnim;
    bool canOpen;
    void Update()
    {
        if (referenceItemA[0].itemIsCheck && referenceItemA[1].itemIsCheck && referenceItemA[2].itemIsCheck && referenceItemA[3].itemIsCheck && referenceItemA[4].itemIsCheck)
        {
            canOpen = true;
        }
        else
        {
            canOpen = false;
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
            if (!canOpen)
            {
                openDoorMessage.SetMessage();
            }
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