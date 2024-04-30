using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompareState : QuestBaseState
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] RoundState roundState;
    [SerializeField] TextManager textManager;
    [SerializeField] int idBtnSelect, score;
    [SerializeField] bool resetGame;
    public int _idBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public bool _resetGame { get => resetGame; set => resetGame = value; }
    void Start()
    {
        score = 1;
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
            StartCoroutine(WinOrLoseMethod(1, "Incorrecto!"));
        }
    }
    IEnumerator WinOrLoseMethod(int _scoreType, string _text)
    {
        if (roundState._currentRound > 5)
        {
            if (score > 2)
            {
                textManager.ShowText(1, "Has ganado el juego!", "txtShow");
                yield return new WaitForSeconds(4f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(2);
            }
            else
            {
                animationsManager.containerCardAnim.SetBool("containerCardHide", true);
                yield return new WaitForSeconds(1f);
                score = 1;
                roundState._currentRound = 1;
                yield return new WaitForSeconds(1f);
                textManager.ShowText(1, "Has perdido!", "txtShow");
                yield return new WaitForSeconds(4f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(2f);
                resetGame = true;
                animationsManager.containerCardAnim.SetBool("containerCardHide", false);
            }
        }
        else
        {
            switch (_scoreType)
            {
                case 0: score++; break;
                case 1: score--; break;
            }
            textManager.ShowText(1, _text, "txtShow");
            yield return new WaitForSeconds(2f);
            resetGame = true;
        }
    }
}