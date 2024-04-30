using UnityEngine;
public class QuestStateManager : MonoBehaviour
{
    QuestBaseState currentState;
    public RoundState roundState = new();
    public TimerState timerState = new();
    public CompareState compareState = new();
    public void Start()
    {
        currentState = roundState;
        currentState.EnterState(this);
    }
    void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(QuestBaseState questBaseState)
    {
        currentState = questBaseState;
        questBaseState.EnterState(this);
    }
}