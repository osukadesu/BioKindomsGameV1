using UnityEngine;
using UnityEngine.AI;
public class AttackStateF : MonoBehaviour
{
    public NavMeshAgent agent;
    public Animator enemiAnim;
    public Transform player;
    public float walkSpeed, attackSpeed;
    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 2f)
        {
            agent.SetDestination(player.position);
            agent.speed = walkSpeed;
            enemiAnim.SetBool("attack", false);
        }
        else
        {
            agent.speed = attackSpeed;
            enemiAnim.SetBool("attack", true);
        }
    }
}