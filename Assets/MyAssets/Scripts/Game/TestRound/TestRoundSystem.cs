using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TestRoundSystem : MonoBehaviour
{
    [SerializeField] Animator containerCardAnim;
    [SerializeField] GameObject timerContainer, CanvasTest;
    [SerializeField] TimerManager timerManager;
    [SerializeField] TextManager textManager;
    [SerializeField] Animator[] cardSelects;
    [SerializeField] Button[] btnCardSelects;
    [SerializeField] QuestLevel questLevel;
    [SerializeField] int currentRound, idBtnSelect = 5;
    [SerializeField] int[] idButton, idQuest;
    [SerializeField] protected internal bool[] btnPressed = { false, false, false };
    [SerializeField] QuestLevelData[] questLevelDatas;
    [SerializeField] AnswerButtonData[] answerButtonDatas;
    [SerializeField] Image _imageKindom;
    [SerializeField] Image[] _imageItem;
    [SerializeField] Text textQuest;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        textManager = FindObjectOfType<TextManager>();
        timerManager = FindObjectOfType<TimerManager>();
        BtnCardsOnclick();
    }
    void Start()
    {
        StartQuest();
        currentRound = 1;
        timerContainer.SetActive(false);
        CanvasTest.SetActive(false);
    }
    void Update()
    {
        SetCaseQuest(questLevel.CaseValue);
        TimerEnd();
        TimerToCompare();
    }
    void SetCaseQuest(int _value)
    {
        switch (_value)
        {
            case 1:
                SetDataCases(0, 0, 0, 0, 0, 1, 2, 0, 1, 2);
                break;
        }
    }
    void SetDataCases(int _idQuest, int _aBtnDatas, int _textQuest, int _imageQuest, int _idImgQ1, int _idImgQ2, int _idImgQ3, int _idImgA1, int _idImgA2, int _idImgA3)
    {
        idQuest[_idQuest] = questLevelDatas[_idQuest].idQuest[_idQuest];
        textQuest.text = questLevelDatas[_textQuest].texQuest[_textQuest];
        _imageKindom.sprite = questLevelDatas[_imageQuest].imageKindom;
        idButton[0] = answerButtonDatas[_aBtnDatas].idAnswer = 0;
        _imageItem[_idImgQ1].sprite = answerButtonDatas[_aBtnDatas].imageItem[_idImgA1];
        idButton[1] = answerButtonDatas[_aBtnDatas].idAnswer = 1;
        _imageItem[_idImgQ2].sprite = answerButtonDatas[_aBtnDatas].imageItem[_idImgA2];
        idButton[2] = answerButtonDatas[_aBtnDatas].idAnswer = 2;
        _imageItem[_idImgQ3].sprite = answerButtonDatas[_aBtnDatas].imageItem[_idImgA3];
        timerContainer.SetActive(true);
        CanvasTest.SetActive(true);
        MouseUnLock();
    }
    void MouseUnLock()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    protected internal void SetCanvasTest()
    {
        CanvasTest.SetActive(true);
        timerContainer.SetActive(true);
    }
    void StartQuest()
    {
        idBtnSelect = 5;
        BtnAnimFalse();
    }
    void BtnAnimFalse()
    {
        AnimationButtons("cardSelect1Move", false);
        AnimationButtons("cardSelect2Move", false);
        AnimationButtons("cardSelect3Move", false);
        containerCardAnim.SetBool("containerCardHide", false);
        btnPressed[0] = false;
        btnPressed[1] = false;
        btnPressed[2] = false;
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
        switch (btnCardValue)
        {
            case 0: SetAnimations(0, "cardSelect1Move", 0); break;
            case 1: SetAnimations(1, "cardSelect2Move", 1); break;
            case 2: SetAnimations(2, "cardSelect3Move", 2); break;
            default: BtnAnimFalse(); break;
        }
    }
    void SetAnimations(int _index, string _nameAnim, int _idBtnSelect)
    {
        idBtnSelect = _idBtnSelect;
        btnPressed[_index] = true;
        AnimationButtons(_nameAnim, true);
        containerCardAnim.SetBool("containerCardHide", true);
    }
    void TimerToCompare()
    {
        if (timerManager.timer < 0)
        {
            CompareCase(questLevel.CaseValue);
        }
    }
    void AnimationButtons(string _nameAnim, bool _boolAnim)
    {
        for (int i = 0; i < cardSelects.Length; i++)
        {
            cardSelects[i].SetBool(_nameAnim, _boolAnim);
        }
    }
    void CompareCase(int cCase)
    {
        switch (cCase)
        {
            case 1:
                CompareCards(0, false);
                break;
        }
    }
    void CompareCards(int _idquest, bool _isReset)
    {
        if (idBtnSelect == idQuest[_idquest])
        {
            WinRound(_isReset);
        }
        else
        {
            LoseRound();
        }
    }
    void WinRound(bool _isReset)
    {
        switch (_isReset)
        {
            case true:
                textManager.ShowText("Incorrecto!", "txtRoundShow");
                StartCoroutine(ResetGame());
                break;
            case false:
                textManager.ShowText("Correcto!", "txtRoundShow");
                StartCoroutine(ChangeScene());
                break;
        }
    }
    IEnumerator ChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
    void LoseRound()
    {
        textManager.ShowText("Incorrecto!", "txtRoundShow");
        StartCoroutine(ResetGame());
    }
    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(2f);
        StartQuest();
    }
    void TimerEnd()
    {
        for (int i = 0; i < btnPressed.Length; i++)
        {
            if (timerManager.timer < 0 && !btnPressed[i])
            {
                StartCoroutine(IETimer());
            }
        }
    }
    IEnumerator IETimer()
    {
        textManager.ShowText("Perdiste!", "txtRoundShow");
        yield return new WaitForSeconds(2f);
        textManager.HideText("txtRoundShow");
        timerManager.timer = 10f;
        timerManager.currentFill = 10f;
    }
}