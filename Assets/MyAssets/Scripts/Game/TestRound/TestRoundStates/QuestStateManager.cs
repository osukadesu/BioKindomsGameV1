using UnityEngine;
public class QuestStateManager : MonoBehaviour
{
    QuestBaseState currentState;
    public RoundState roundState;
    public TimerState timerState;
    public CompareState compareState;
    void Start()
    {
        currentState = roundState;
        currentState.EnterState(this);
    }
    void Update() => currentState.UpdateState(this);
    public void SwitchState(QuestBaseState questBaseState)
    {
        currentState = questBaseState;
        questBaseState.EnterState(this);
    }
}