using System.Collections;
using UnityEngine;
public class StartRoundSystem : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] TextManager textManager;
    [SerializeField] TimerManager timerManager;
    [SerializeField] LogicQuestSystem logicQuestSystem;
    [SerializeField] CompareSystem compareSystem;
    [SerializeField] int currentRound;
    public int _CurrentRound { get => currentRound; set => currentRound = value; }
    void Awake()
    {
        //questLevel = FindObjectOfType<QuestLevel>();
        setQuestSystem = FindObjectOfType<SetQuestSystem>();
        compareSystem = FindObjectOfType<CompareSystem>();
        timerManager = FindObjectOfType<TimerManager>();
        logicQuestSystem = FindObjectOfType<LogicQuestSystem>();
    }
    void Start()
    {
        currentRound = 1;
        StartQuest(9.5f, 3.5f, 1f, 1f);
    }
    public void StartQuest(float _timeToCompare, float _timemethod, float _timeNotSelect1, float _timeNotSelect2)
    {
        setQuestSystem.SetCase(0/*questLevel.CaseValue*/);
        logicQuestSystem.ResetUCS();
        compareSystem._startGame = true;
        timerManager._TimerForMethod = _timemethod;
        compareSystem._idBtnSelect = 3;
        StartCoroutine(IEStartQuest(_timeNotSelect1, _timeNotSelect2));
        compareSystem.TimeToCompare(_timeToCompare);
    }
    public IEnumerator IEStartQuest(float _timerIESQInit, float _timerIESQEnd)
    {
        yield return new WaitForSeconds(_timerIESQInit);
        textManager.ShowText(0, "Round " + currentRound, "txtShow");
        yield return new WaitForSeconds(_timerIESQEnd);
    }
}