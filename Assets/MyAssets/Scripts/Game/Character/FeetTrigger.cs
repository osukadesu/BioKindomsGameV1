using UnityEngine;
public class FeetTrigger : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    private void Awake() => playerMove = FindObjectOfType<PlayerMove>();
    private void OnTriggerStay(Collider other) => playerMove.CanJump = true;
    private void OnTriggerExit(Collider other) => playerMove.CanJump = false;
}