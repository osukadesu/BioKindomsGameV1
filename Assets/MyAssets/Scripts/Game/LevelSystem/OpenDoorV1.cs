using UnityEngine;
public class OpenDoorV1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemA;
    [SerializeField] Animator openDoorAnim;
    [SerializeField] bool canOpen;
    void Update()
    {
        canOpen = referenceItemA[0].itemIsCheck && referenceItemA[1].itemIsCheck && referenceItemA[2].itemIsCheck &&
        referenceItemA[3].itemIsCheck && referenceItemA[4].itemIsCheck;
        openDoorMessage.UnlockDoors(0, "unlockDoor", canOpen);
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player"))
        {
            openDoorMessage.SetMessage(!canOpen ? 0 : CanOpenIsTrue(1), .2f);
        }
    }
    int CanOpenIsTrue(int _case)
    {
        openDoorAnim.SetBool("openDoor", true);
        openDoorMessage.SetMessage(_case, .2f);
        return _case;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openDoorAnim.SetBool("openDoor", false);
            openDoorMessage.SetMessage(1, .2f);
        }
    }
}