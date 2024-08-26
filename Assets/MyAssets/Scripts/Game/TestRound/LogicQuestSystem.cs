using UnityEngine;
using UnityEngine.UI;
public class LogicQuestSystem : MonoBehaviour
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] QuestCaseData questCaseData;
    [SerializeField] public Button[] btnCardSelects;
    void Awake()
    {
        questCaseData = FindObjectOfType<QuestCaseData>();
        animationsManager = FindObjectOfType<AnimationsManager>();
        BtnCardsOnclick();
    }
    public void BtnIsEnabled(bool _isEnabled)
    {
        for (int i = 0; i < btnCardSelects.Length; i++)
        {
            btnCardSelects[i].enabled = _isEnabled;
        }
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
            case 0: animationsManager.SetAnimations(questCaseData._idButton[0], 0, "cardSelect1Move"); break;
            case 1: animationsManager.SetAnimations(questCaseData._idButton[1], 1, "cardSelect2Move"); break;
            case 2: animationsManager.SetAnimations(questCaseData._idButton[2], 2, "cardSelect3Move"); break;
            default: ResetUCS(); break;
        }
    }
    public void ResetUCS()
    {
        animationsManager.BtnLogicFalse();
    }
}