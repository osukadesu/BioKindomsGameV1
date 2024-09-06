using UnityEngine;
public class WalkingState : EnemyBaseState
{
    public int wayIndex = 0;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.agent.SetDestination(enemyStateManager.wayPoints[wayIndex].position);
        enemyStateManager.agent.speed = enemyStateManager.walkSpeed;
        if (Vector3.Distance(enemyStateManager.wayPoints[wayIndex].position, transform.position) < 3f)
        {
            wayIndex++;
            if (wayIndex >= enemyStateManager.wayPoints.Length)
            {
                wayIndex = 0;
            }
        }
        if (Vector3.Distance(enemyStateManager.player.position, transform.position) < 6f)
        {
            enemyStateManager.SwitchState(enemyStateManager.attackState);
        }
    }
}