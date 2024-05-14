using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CompareSystem : MonoBehaviour
{
    [SerializeField] SetQuestSystem setQuestSystem;
    [SerializeField] StartRoundSystem startRoundSystem;
    [SerializeField] TimerManager timerManager;
    [SerializeField] TextManager textManager;
    [SerializeField] protected internal GameObject timerContent, questContent, cardContent;
    [SerializeField] int score, idBtnSelect;
    [SerializeField] bool gameFinished, startGame;
    public bool _startGame { get => startGame; set => startGame = value; }
    public int _idBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public bool _gameFinished { get => gameFinished; set => gameFinished = value; }
    public int _score { get => score; set => score = value; }
    void Awake()
    {
        startRoundSystem = FindObjectOfType<StartRoundSystem>();
        setQuestSystem = FindObjectOfType<SetQuestSystem>();
        textManager = FindObjectOfType<TextManager>();
        timerManager = FindObjectOfType<TimerManager>();
    }
    void Start()
    {
        SetContainers(true);
        score = 0;
        idBtnSelect = 3;
        gameFinished = false;
    }
    public void TimeToCompare(float _timeAdd)
    {
        StartCoroutine(IETimeToCompare(_timeAdd));
    }
    IEnumerator IETimeToCompare(float _timeAdd)
    {
        yield return new WaitForSeconds(_timeAdd);
        CompareCards(setQuestSystem._myRandom);
    }
    void CompareCards(int _idquest)
    {
        startGame = false;
        gameFinished = true;
        startRoundSystem._CurrentRound++;
        if (idBtnSelect == setQuestSystem._idQuest[_idquest] && idBtnSelect != 3)
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
        switch (_scoreType)
        {
            case 0: score++; break;
            case 1: score--; break;
        }
        timerManager._TimerForMethod = 3f;
        textManager.ShowText(1, _text, "txtShow");
        yield return new WaitForSeconds(2f);
        ResetGame(false, null, null, 3f, 9.5f, 3.5f);
        yield return new WaitForSeconds(1f);
        if (startRoundSystem._CurrentRound > 5)
        {
            yield return new WaitForSeconds(2f);
            if (score > 2)
            {
                textManager.ShowText(1, "Has ganado el juego!", "txtShow");
                yield return new WaitForSeconds(2f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(2f);
                SceneManager.LoadScene(2);
            }
            else
            {
                SetContainers(false);
                textManager.ShowText(1, "Has perdido!", "txtRoundShow");
                yield return new WaitForSeconds(2f);
                textManager.ShowText(1, "Puntaje: " + score, "txtShow");
                yield return new WaitForSeconds(1f);
                ResetGame(false, 1, 0, 3f, 9.5f, 3.5f);
            }
        }
    }
    public void ResetGame(bool _GF, int? _CR, int? _S, float _IERV, float _SQ, float _SQ2)
    {
        gameFinished = _GF;
        startRoundSystem._CurrentRound = _CR ?? startRoundSystem._CurrentRound;
        score = _S ?? score;
        StartCoroutine(timerManager.IEResetValues(_IERV));
        startRoundSystem.StartQuest(_SQ, _SQ2, 1f, 1f);
        cardContent.SetActive(true);
    }
    public IEnumerator ResetGameForNotSelect(bool _GF, int? _CR, int? _S, float _SQ, float _SQ2)
    {
        gameFinished = _GF;
        startRoundSystem._CurrentRound = _CR ?? startRoundSystem._CurrentRound;
        score = _S ?? score;
        startRoundSystem.StartQuest(_SQ, _SQ2, 5f, 5f);
        yield return new WaitForSeconds(2f);
        cardContent.SetActive(true);
    }
    void SetContainers(bool _bool)
    {
        timerContent.SetActive(_bool);
        questContent.SetActive(_bool);
        cardContent.SetActive(_bool);
    }
}