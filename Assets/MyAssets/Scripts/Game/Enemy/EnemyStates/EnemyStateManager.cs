using UnityEngine;
using UnityEngine.AI;
public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public WalkingState walkingState;
    public AttackState attackState;
    public NavMeshAgent agent;
    public Transform player;
    public float walkSpeed, attackSpeed;
    public void Start()
    {
        currentState = walkingState;
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(EnemyBaseState enemyBaseState)
    {
        currentState = enemyBaseState;
    }
}