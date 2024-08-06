using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    EnemyBaseState currentState;
    public WalkingState walkingState = new();
    public AttackState attackState = new();
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
