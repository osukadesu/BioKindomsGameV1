using UnityEngine;
public class AttackState : EnemyBaseState
{
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (Vector3.Distance(enemyStateManager.player.position, transform.position) > 6f)
        {
            enemyStateManager.agent.speed = enemyStateManager.walkSpeed;
            enemyStateManager.enemiAnim.SetBool("attack", false);
            enemyStateManager.SwitchState(enemyStateManager.walkingState);
        }
        else
        {
            enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
            enemyStateManager.agent.speed = enemyStateManager.attackSpeed;
            enemyStateManager.enemiAnim.SetBool("attack", true);
        }
    }
}