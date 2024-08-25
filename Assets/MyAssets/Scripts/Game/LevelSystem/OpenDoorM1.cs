using UnityEngine;
public class OpenDoorM1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemP;
    [SerializeField] Animator openDoorAnim;
    [SerializeField] bool canOpen;
    void Update()
    {
        canOpen = referenceItemP[0].itemIsCheck && referenceItemP[1].itemIsCheck && referenceItemP[2].itemIsCheck &&
        referenceItemP[3].itemIsCheck && referenceItemP[4].itemIsCheck;
        openDoorMessage.UnlockDoors(3, "unlockDoor", canOpen);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canOpen)
        {
            openDoorAnim.SetBool("openDoor", true);
            openDoorMessage.SetMessage(1, .2f);
        }
        else
        {
            openDoorMessage.SetMessage(1, .2f);
        }
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