using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TestRoundSystem : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] TextManager textManager;
    [SerializeField] TimerManager timerManager;
    [SerializeField] QuestLevelData questLevelDatas;
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] AnswerButtonData[] answerButtonDatas;
    [SerializeField] Text textQuest;
    [SerializeField] Image _imageKindom;
    [SerializeField] Image[] _imageItem;
    [SerializeField] Button[] btnCardSelects;
    [SerializeField] int _Random, currentRound, score, idBtnSelect = 3;
    [SerializeField] int[] idButton, idQuest;
    [SerializeField] bool gameFinished = false, startGame;
    [SerializeField] public bool StartGame { get => startGame; set => startGame = value; }
    [SerializeField] protected internal int IdBtnSelect { get => idBtnSelect; set => idBtnSelect = value; }
    public int _CurrentRound { get => currentRound; set => currentRound = value; }
    void Awake()
    {
        //questLevel = FindObjectOfType<QuestLevel>();
        animationsManager = FindObjectOfType<AnimationsManager>();
        textManager = FindObjectOfType<TextManager>();
        timerManager = FindObjectOfType<TimerManager>();
        BtnCardsOnclick();
    }
    void Start()
    {
        currentRound = 1;
        score = 0;
        StartCoroutine(StartQuest(1));
    }
    void BtnCardsOnclick()
    {
        for (int i = 0; i < btnCardSelects.Length; i++)
        {
            int _iterator = i;
            btnCardSelects[i].onClick.AddListener(() => UserCardSelect(_iterator));
        }
    }
    void UserCardSelect(int btnCardValue)
    {
        if (!gameFinished)
        {
            switch (btnCardValue)
            {
                case 0: animationsManager.SetAnimations(0, "cardSelect1Move"); break;
                case 1: animationsManager.SetAnimations(1, "cardSelect2Move"); break;
                case 2: animationsManager.SetAnimations(2, "cardSelect3Move"); break;
                default: animationsManager.BtnLogicFalse(); break;
            }
        }
    }
    IEnumerator StartQuest(int _type)
    {
        _Random = Random.Range(1, 3);
        Debug.Log("Set Random" + _Random);
        SetCases(1);
        animationsManager.BtnLogicFalse();
        startGame = true;
        timerManager._TimerForMethod = 3f;
        idBtnSelect = 3;
        yield return new WaitForSeconds(1f);
        textManager.ShowText("Round " + currentRound, "txtRoundShow");
        StartCoroutine(TimeToCompare(_type));
    }
    IEnumerator TimeToCompare(int _type)
    {
        switch (_type)
        {
            case 1:
                yield return new WaitForSeconds(timerManager.Timer + 3f);
                CompareCase(_Random);
                break;
            case 2:
                yield return new WaitForSeconds(timerManager.Timer + 6f);
                CompareCase(_Random);
                break;
        }
    }
    void SetCases(int _value)
    {
        switch (_value)
        {
            case 1:
                AnimalQuest(_Random);
                break;
        }
    }
    void AnimalQuest(int _value)
    {
        switch (_value)
        {
            case 1:
                SetDataCases(0, 0, 0, 0, 1, 2);
                break;
            case 2:
                SetDataCases(1, 1, 0, 0, 2, 3);
                break;
            /*
              case 3:
                  SetDataCases(0, 0, 0, 0, 1, 2, 0, 1, 2);
                  break;
              case 4:
                  SetDataCases(0, 0, 0, 0, 1, 2, 0, 1, 2);
                  break;
              case 5:
                  SetDataCases(0, 0, 0, 0, 1, 2, 0, 1, 2);
                  break;
            */
            default:
                Debug.LogError("Quest error!");
                break;
        }
    }
    void SetDataCases(int _idQuest, int _textQuest, int _imageQuest, int _idImgA1, int _idImgA2, int _idImgA3)
    {
        idQuest[_idQuest] = questLevelDatas.idQuest[_idQuest];
        textQuest.text = questLevelDatas.texQuest[_textQuest];
        _imageKindom.sprite = questLevelDatas.imageKindom[_imageQuest];
        idButton[0] = answerButtonDatas[0].idAnswer = 0;
        _imageItem[0].sprite = answerButtonDatas[0].imageItem[_idImgA1];
        idButton[1] = answerButtonDatas[1].idAnswer = 1;
        _imageItem[1].sprite = answerButtonDatas[1].imageItem[_idImgA2];
        idButton[2] = answerButtonDatas[2].idAnswer = 2;
        _imageItem[2].sprite = answerButtonDatas[2].imageItem[_idImgA3];
        MouseUnLock();
    }
    void MouseUnLock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    void CompareCase(int cCase)
    {
        switch (cCase)
        {
            case 1:
                CompareCards(0);
                break;
            case 2:
                CompareCards(1);
                break;
        }
    }
    void CompareCards(int _idquest)
    {
        startGame = false;
        gameFinished = true;
        currentRound++;
        Debug.Log("Current Round: " + currentRound);
        if (idBtnSelect == idQuest[_idquest] && idBtnSelect != 3)
        {
            StartCoroutine(WinRound());
        }
        else
        {
            StartCoroutine(LoseRound());
        }
    }
    IEnumerator WinRound()
    {
        score++;
        timerManager._TimerForMethod = 3f;
        textManager.ShowText("Correcto!", "txtRoundShow");
        yield return new WaitForSeconds(2f);
        ResetGame(0);
        if (currentRound > 4)
        {
            textManager.ShowText("Juego terminado!", "txtRoundShow");
            textManager.ShowText("Puntaje: " + score, "txtRoundShow");
            if (score > 4)
            {
                textManager.ShowText("Has ganado!", "txtRoundShow");
                ChangeScene();
            }
            else
            {
                textManager.ShowText("Has perdido!", "txtRoundShow");
                ResetGame(0);
            }
        }
        else
        {
            ResetGame(0);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(2);
    }
    public IEnumerator LoseRound()
    {
        score--;
        timerManager._TimerForMethod = 8f;
        yield return new WaitForSeconds(2f);
        textManager.ShowText("Incorrecto!", "txtRoundShow");
        yield return new WaitForSeconds(2f);
        ResetGame(1);
        if (currentRound > 4 && score < 4)
        {
            textManager.ShowText("Has Perdido!", "txtRoundShow");
            textManager.ShowText("Puntaje: " + score, "txtRoundShow");
            ResetGame(2);
        }
    }
    void ResetGame(int ver)
    {
        gameFinished = false;
        switch (ver)
        {
            case 0:
                StartCoroutine(timerManager.IEResetValues(2));
                StartCoroutine(StartQuest(1));
                break;
            case 1:
                StartCoroutine(timerManager.IEResetValues(currentRound));
                StartCoroutine(StartQuest(2));
                break;
            case 2:
                currentRound = 1;
                score = 1; StartCoroutine(timerManager.IEResetValues(currentRound));
                StartCoroutine(StartQuest(1));
                break;
        }
    }
}