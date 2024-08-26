using UnityEngine;
public class OpenDoorF1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemV;
    [SerializeField] Animator openDoorAnim;
    [SerializeField] bool canOpen;
    void Update()
    {
        canOpen = referenceItemV[0].itemIsCheck && referenceItemV[1].itemIsCheck && referenceItemV[2].itemIsCheck &&
        referenceItemV[3].itemIsCheck && referenceItemV[4].itemIsCheck;
        openDoorMessage.UnlockDoors(1, "unlockDoor", canOpen);
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