using UnityEngine;
public class OpenDoor : MonoBehaviour
{
    [SerializeField] Animator doorAnim;
    void Start()
    {
        doorAnim.SetBool("openDoor", false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("openDoor", true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorAnim.SetBool("openDoor", false);
        }
    }
}