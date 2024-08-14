using UnityEngine;
public class OpenDoorF1 : MonoBehaviour
{
    [SerializeField] OpenDoorMessage openDoorMessage;
    [SerializeField] InventoryItemDataV2[] referenceItemV;
    [SerializeField] Animator openDoorAnim;
    bool canOpen;
    void Update()
    {
        for (int i = 0; i < referenceItemV.Length; i++)
        {
            if (referenceItemV[i].itemIsCheck)
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
            openDoorMessage.SetMessage(0, 0f);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            openDoorAnim.SetBool("openDoor", false);
            openDoorMessage.SetMessage(1, 1f);
        }
    }
}