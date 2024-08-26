using UnityEngine;
using UnityEngine.UI;
public class TimerState : QuestBaseState
{
    [SerializeField] LogicQuestSystem logicQuestSystem;
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] RoundState roundState;
    [SerializeField] protected internal Animator hiderTimer;
    [SerializeField] Text textTimer;
    [SerializeField] Image imgFiller;
    [SerializeField] int fillMax;
    [SerializeField] float timer, currentFill;
    void Awake()
    {
        logicQuestSystem = FindObjectOfType<LogicQuestSystem>();
    }
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
            hiderTimer.SetBool("hideTimer", true);
            logicQuestSystem.BtnIsEnabled(true);
            timer -= Time.deltaTime;
            currentFill -= Time.deltaTime;
            float timerRound = Mathf.Round(timer);
            textTimer.text = timerRound.ToString();
            animationsManager.SetTimerAnimation(true);
        }
    }
}