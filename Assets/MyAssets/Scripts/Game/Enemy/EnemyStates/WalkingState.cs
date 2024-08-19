using UnityEngine;
public class WalkingState : EnemyBaseState
{
    [SerializeField] Transform[] wayPoints;
    public int wayIndex = 0;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        enemyStateManager.agent.SetDestination(wayPoints[wayIndex].position);
        enemyStateManager.agent.speed = 2;
        if (Vector3.Distance(wayPoints[wayIndex].position, transform.position) < 3f)
        {
            wayIndex++;
            if (wayIndex >= wayPoints.Length)
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