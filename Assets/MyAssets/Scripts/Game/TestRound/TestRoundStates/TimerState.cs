using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TimerState : QuestBaseState
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] RoundState roundState;
    [SerializeField] GameObject timerContainer;
    [SerializeField] Text textTimer;
    [SerializeField] Image imgFiller;
    [SerializeField] int fillMax;
    [SerializeField] float timer, currentFill;
    public override void EnterState(QuestStateManager questStateManager)
    {
        fillMax = 5;
        timer = 5f;
        currentFill = 5f;
    }
    public override void UpdateState(QuestStateManager questStateManager)
    {
        TimerMethod();
        imgFiller.fillAmount = currentFill / fillMax;
        if (timer < 0)
        {
            timer = 5f;
            currentFill = 5f;
            animationsManager.SetTimerAnimation(false);
            questStateManager.SwitchState(questStateManager.compareState);
        }
    }
    void TimerMethod()
    {
        if (timer > 0 && roundState._startGame)
        {
            timerContainer.SetActive(true);
            timer -= Time.deltaTime;
            currentFill -= Time.deltaTime;
            float timerRound = Mathf.Round(timer);
            textTimer.text = timerRound.ToString();
            animationsManager.SetTimerAnimation(true);
        }
    }
}