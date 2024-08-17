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
            openDoorAnim.SetBool("openDoor", false);
            openDoorMessage.SetMessage(0, 0f);
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