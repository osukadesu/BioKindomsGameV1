using System.Collections;
using UnityEngine;
public class AttackState : EnemyBaseState
{
    [SerializeField] Animator enemiAnim;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (Vector3.Distance(enemyStateManager.player.position, transform.position) > 6f)
        {
            enemyStateManager.agent.speed = 2;
            StopCoroutine(EnemyAttack());
            enemyStateManager.SwitchState(enemyStateManager.walkingState);
        }
        else
        {
            enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
            enemyStateManager.agent.speed = 3;
            StartCoroutine(EnemyAttack());
        }
    }
    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        enemiAnim.SetBool("attack", true);
    }
}