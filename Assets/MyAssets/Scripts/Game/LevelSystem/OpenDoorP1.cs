using UnityEngine;
public class OpenDoorP1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemF;
    [SerializeField] Animator openDoorAnim;
    [SerializeField] bool canOpen;
    void Update()
    {
         canOpen = referenceItemF[0].itemIsCheck && referenceItemF[1].itemIsCheck && referenceItemF[2].itemIsCheck &&
        referenceItemF[3].itemIsCheck && referenceItemF[4].itemIsCheck;
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