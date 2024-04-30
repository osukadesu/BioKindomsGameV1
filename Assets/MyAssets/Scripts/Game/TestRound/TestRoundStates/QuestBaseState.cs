using UnityEngine;

public abstract class QuestBaseState : MonoBehaviour
{
    public abstract void EnterState(QuestStateManager questStateManager);
    public abstract void UpdateState(QuestStateManager questStateManager);
}