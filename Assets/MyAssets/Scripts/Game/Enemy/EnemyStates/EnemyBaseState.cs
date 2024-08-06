using UnityEngine;
public abstract class EnemyBaseState : MonoBehaviour
{
    public abstract void UpdateState(EnemyStateManager enemyStateManager);
}