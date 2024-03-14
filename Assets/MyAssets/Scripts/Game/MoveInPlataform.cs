using UnityEngine;
public class MoveInPlataform : MonoBehaviour
{
    /*
    [SerializeField] CharacterController player;
    [SerializeField] Vector3 groundPosition, lastGroundPosition;
    [SerializeField] string groundName, lastGroundName;
    void Start()
    {
        player = FindObjectOfType<CharacterController>();
    }
    void Update()
    {
        if (player.isGrounded)
        {
            if (Physics.SphereCast(transform.position, player.height / 4.1f, -transform.up, out RaycastHit hit))
            {
                GameObject groundedIn = hit.collider.gameObject;
                groundName = groundedIn.name;
                groundPosition = groundedIn.transform.position;
                if (groundPosition != lastGroundPosition && groundName == lastGroundName)
                {
                    //this.transform.position += groundPosition - lastGroundPosition;
                    this.gameObject.transform.SetParent(transform);
                }
                lastGroundName = groundName;
                lastGroundPosition = groundPosition;
            }
        }
        else if (!player.isGrounded)
        {
            lastGroundName = null;
            lastGroundPosition = Vector3.zero;
            this.gameObject.transform.SetParent(null);
        }
    }
    public void OnDrawGizmos()
    {
        player = FindObjectOfType<CharacterController>();
        Gizmos.DrawWireSphere(transform.position, player.height / 4.1f);
    }
    */
}