using UnityEngine;
using UnityEngine.AI;
public class WalkingState : EnemyBaseState
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform[] wayPoints;
    [SerializeField] Transform player;
    public int wayIndex = 0;
    public override void UpdateState(EnemyStateManager enemyStateManager)
    {
        agent.SetDestination(wayPoints[wayIndex].position);
        agent.speed = 2;
        if (Vector3.Distance(wayPoints[wayIndex].position, transform.position) < 3f)
        {

            wayIndex++;
            if (wayIndex >= wayPoints.Length)
            {
                wayIndex = 0;
            }
        }
        if (Vector3.Distance(player.position, transform.position) < 6f)
        {
            enemyStateManager.SwitchState(enemyStateManager.attackState);
        }
    }
}