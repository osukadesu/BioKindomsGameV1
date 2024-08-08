using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompareState : QuestBaseState
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] SaveScoreMethod saveScoreMethod;
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] RoundState roundState;
    [SerializeField] TextManager textManager;
    [SerializeField] int idBtnSelect, score;
    [SerializeField] bool resetGame;
    public int _idBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public bool _resetGame { get => resetGame; set => resetGame = value; }
    public int _score { get => score; set => score = value; }
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
    }
    void Start()
    {
        idBtnSelect = 5;
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
            idBtnSelect = 5;
            questStateManager.SwitchState(questStateManager.roundState);
        }
    }
    void CompareMethod(int _idquest)
    {
        roundState._startGame = false;
        roundState._currentRound++;
        if (idBtnSelect == setQuestSystem._idQuest[_idquest] && idBtnSelect != 5)
        {
            StartCoroutine(WinOrLoseMethod(0, "Correcto!"));
        }
        else
        {
            animationsManager.containerCardAnim.SetBool("containerCardHide", true);
            if (idBtnSelect == 5)
            {
                StartCoroutine(WinOrLoseMethod(1, "No seleccionaste!"));
            }
            else
            {
                StartCoroutine(WinOrLoseMethod(1, "Incorrecto!"));
            }
        }
    }
    IEnumerator WinOrLoseMethod(int _scoreType, string _text)
    {
        if (_scoreType == 0 && score < 5)
        {
            score++;
        }
        else if (_scoreType == 1 && score > 1)
        {
            score--;
        }
        yield return new WaitForSeconds(.5f);
        if (roundState._currentRound > 5)
        {
            if (score > 2)
            {
                textManager.ShowText(1, "Has ganado el juego!", "txtShow");
                yield return new WaitForSeconds(4f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(2f);
                saveScoreMethod.SavingScore();
                questLevel._endQuest = true;
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(4);
            }
            else
            {
                animationsManager.containerCardAnim.SetBool("containerCardHide", true);
                yield return new WaitForSeconds(1f);
                roundState._currentRound = 1;
                yield return new WaitForSeconds(1f);
                textManager.ShowText(1, "Has perdido!", "txtShow");
                yield return new WaitForSeconds(4f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(2f);
                saveScoreMethod.SavingScore();
                questLevel._endQuest = true;
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(4);
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
}