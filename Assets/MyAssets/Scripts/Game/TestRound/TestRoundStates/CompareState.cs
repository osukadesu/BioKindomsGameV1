using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompareState : QuestBaseState
{
    [SerializeField] QuestCaseRandom questCaseRandom;
    [SerializeField] SaveScoreMethod saveScoreMethod;
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] QuestCaseData questCaseData;
    [SerializeField] RoundState roundState;
    [SerializeField] TextManager textManager;
    [SerializeField] int idBtnSelect, score, correct, incorrect;
    public int[] _score = new int[5];
    [SerializeField] bool resetGame;
    public int _idBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public bool _resetGame { get => resetGame; set => resetGame = value; }
    void Awake()
    {
        questCaseRandom = FindObjectOfType<QuestCaseRandom>();
        questCaseData = FindObjectOfType<QuestCaseData>();
    }
    void Start()
    {
        idBtnSelect = -1;
    }
    public override void EnterState(QuestStateManager questStateManager)
    {
        CompareMethod(questCaseRandom.MyRandom);
    }
    public override void UpdateState(QuestStateManager questStateManager)
    {
        if (resetGame)
        {
            idBtnSelect = -1;
            questStateManager.SwitchState(questStateManager.roundState);
        }
    }
    void CompareMethod(int _idquest)
    {
        roundState._startGame = false;
        roundState._currentRound++;
        if (idBtnSelect == questCaseData._idQuest[_idquest] && idBtnSelect != -1)
        {
            StartCoroutine(WinOrLoseMethod(0, "Correcto!"));
        }
        else
        {
            animationsManager.containerCardAnim.SetBool("containerCardHide", true);
            StartCoroutine(WinOrLoseMethod(1, idBtnSelect == -1 ? "No seleccionaste!" : "Incorrecto!"));
        }
    }
    IEnumerator WinOrLoseMethod(int _scoreType, string _text)
    {
        correct = (_scoreType == 0) ? correct + 1 : correct;
        incorrect = (_scoreType == 1) ? incorrect + 1 : incorrect;
        yield return new WaitForSeconds(.5f);
        IEnumerator ShowResult(string _message)
        {
            textManager.ShowText(1, _message, "txtShow");
            yield return new WaitForSeconds(2.5f);
            textManager.ShowText(1, "Puntaje: " + score, "txtShow");
            yield return new WaitForSeconds(2f);
            ScoreCase(GeneralSingleton.generalSingleton.CaseValue);
            saveScoreMethod.SavingScore();
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(GeneralSingleton.generalSingleton.isMyProfile ? 3 : 4);
        }
        if (roundState._currentRound > 5)
        {
            score = (5 + (correct - incorrect)) / 2;
            GeneralSingleton.generalSingleton.endQuest[GeneralSingleton.generalSingleton.CaseValue] = true;
            yield return new WaitForSeconds(1f);
            if (score > 2)
            {
                yield return ShowResult("Has ganado el quiz!");
            }
            else
            {
                animationsManager.containerCardAnim.SetBool("containerCardHide", true);
                yield return new WaitForSeconds(.5f);
                roundState._currentRound = 1;
                yield return new WaitForSeconds(.5f);
                yield return ShowResult("Has perdido el quiz!");
            }
        }
        else
        {
            textManager.ShowText(1, _text, "txtShow");
            yield return new WaitForSeconds(2f);
            GeneralSingleton.generalSingleton.endQuest[GeneralSingleton.generalSingleton.CaseValue] = false;
            resetGame = true;
        }
    }
    void ScoreCase(int _case)
    {
        for (int i = 0; i < _score.Length; i++)
        {
            _score[i] = (i == _case) ? score : GeneralSingleton.generalSingleton._num[i];
        }
    }
}