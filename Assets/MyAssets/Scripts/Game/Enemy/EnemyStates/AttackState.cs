using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class AttackState : EnemyBaseState
{
    [SerializeField] Animator enemiAnim;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform player;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (Vector3.Distance(player.position, transform.position) > 6f)
        {
            agent.speed = 2;
            StopCoroutine(EnemyAttack());
            enemyStateManager.SwitchState(enemyStateManager.walkingState);
        }
        else
        {
            agent.SetDestination(player.position);
            agent.speed = 3;
            StartCoroutine(EnemyAttack());
        }
    }
    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        enemiAnim.SetBool("attack", true);
    }
}