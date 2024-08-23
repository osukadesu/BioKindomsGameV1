using System.Collections;
using UnityEngine;
public class AttackState : EnemyBaseState
{
    [SerializeField] Animator enemiAnim;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (Vector3.Distance(enemyStateManager.player.position, transform.position) > 6f)
        {
            enemyStateManager.agent.speed = enemyStateManager.walkSpeed;
            StopCoroutine(EnemyAttack(false));
            enemyStateManager.SwitchState(enemyStateManager.walkingState);
        }
        else
        {
            enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
            enemyStateManager.agent.speed = enemyStateManager.attackSpeed;
            StartCoroutine(EnemyAttack(true));
        }
    }
    IEnumerator EnemyAttack(bool _isAttack)
    {
        yield return new WaitForSeconds(1f);
        enemiAnim.SetBool("attack", _isAttack);
    }
}