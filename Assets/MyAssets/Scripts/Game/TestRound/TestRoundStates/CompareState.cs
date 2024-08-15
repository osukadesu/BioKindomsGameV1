using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompareState : QuestBaseState
{
    [SerializeField] LoadProfileSingleton loadProfileSingleton;
    [SerializeField] QuestLevel questLevel;
    [SerializeField] SaveScoreMethod saveScoreMethod;
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] RoundState roundState;
    [SerializeField] TextManager textManager;
    [SerializeField] int idBtnSelect, score;
    public int[] _score = new int[5];
    [SerializeField] bool resetGame;
    public int _idBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public bool _resetGame { get => resetGame; set => resetGame = value; }
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        loadProfileSingleton = FindObjectOfType<LoadProfileSingleton>();
    }
    void Start()
    {
        idBtnSelect = 10;
        score = 5;
    }
    public override void EnterState(QuestStateManager questStateManager)
    {
        CompareMethod(setQuestSystem._myRandom);
    }
    public override void UpdateState(QuestStateManager questStateManager)
    {
        if (resetGame)
        {
            idBtnSelect = 10;
            questStateManager.SwitchState(questStateManager.roundState);
        }
    }
    void CompareMethod(int _idquest)
    {
        roundState._startGame = false;
        roundState._currentRound++;
        if (idBtnSelect == setQuestSystem._idQuest[_idquest] && idBtnSelect != 10)
        {
            StartCoroutine(WinOrLoseMethod(0, "Correcto!"));
        }
        else
        {
            animationsManager.containerCardAnim.SetBool("containerCardHide", true);
            StartCoroutine(WinOrLoseMethod(1, idBtnSelect == 10 ? "No seleccionaste!" : "Incorrecto!"));
        }
    }
    IEnumerator WinOrLoseMethod(int _scoreType, string _text)
    {
        score = (_scoreType == 0 && score < 5) ? score + 1 : (_scoreType == 1 && score > 1) ? score - 1 : score;
        yield return new WaitForSeconds(.5f);
        IEnumerator ShowResult(string _message)
        {
            textManager.ShowText(1, _message, "txtShow");
            yield return new WaitForSeconds(2.5f);
            textManager.ShowText(1, "Puntaje: " + score, "txtShow");
            yield return new WaitForSeconds(2f);
            ScoreCase(questLevel.CaseValue);
            saveScoreMethod.SavingScore();
            questLevel._endQuest = true;
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene(MenuController.menuController.IsMyProfile ? 3 : 4);
        }
        if (roundState._currentRound > 5)
        {
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
            questLevel._endQuest = false;
            resetGame = true;
        }
    }
    void ScoreCase(int _case)
    {
        for (int i = 0; i < _score.Length; i++)
        {
            _score[i] = (i == _case) ? score : loadProfileSingleton._num[i];
        }
    }
}