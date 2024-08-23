using UnityEngine;
public class AttackState : EnemyBaseState
{
    [SerializeField] Animator enemiAnim;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        if (Vector3.Distance(enemyStateManager.player.position, transform.position) > 6f)
        {
            enemyStateManager.agent.speed = enemyStateManager.walkSpeed;
            enemiAnim.SetBool("attack", false);
            enemyStateManager.SwitchState(enemyStateManager.walkingState);
        }
        else
        {
            enemyStateManager.agent.SetDestination(enemyStateManager.player.position);
            enemyStateManager.agent.speed = enemyStateManager.attackSpeed;
            enemiAnim.SetBool("attack", true);
        }
    }
}