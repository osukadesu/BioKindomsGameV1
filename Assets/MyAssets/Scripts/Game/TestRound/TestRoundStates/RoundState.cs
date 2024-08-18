using System.Collections;
using UnityEngine;
public class RoundState : QuestBaseState
{
    [SerializeField] TextManager textManager;
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] LogicQuestSystem logicQuestSystem;
    [SerializeField] CompareState compareState;
    [SerializeField] int currentRound;
    [SerializeField] bool startGame;
    public bool _startGame { get => startGame; set => startGame = value; }
    public int _currentRound { get => currentRound; set => currentRound = value; }
    void Start()
    {
        startGame = false;
        currentRound = 1;
    }
    public override void EnterState(QuestStateManager questStateManager)
    {
        StartQuest();
    }
    public override void UpdateState(QuestStateManager questStateManager)
    {
        if (startGame)
        {
            questStateManager.SwitchState(questStateManager.timerState);
        }
    }
    void StartQuest()
    {
        compareState._resetGame = false;
        setQuestSystem.SetCase(GeneralSingleton.generalSingleton.CaseValue);
        logicQuestSystem.ResetUCS();
        StartCoroutine(IEStartQuest());
        Debug.Log("Quest value: " + GeneralSingleton.generalSingleton.CaseValue);
    }
    IEnumerator IEStartQuest()
    {
        yield return new WaitForSeconds(1f);
        textManager.ShowText(0, "Round " + currentRound, "txtShow");
        yield return new WaitForSeconds(2.4f);
        startGame = true;
    }
}