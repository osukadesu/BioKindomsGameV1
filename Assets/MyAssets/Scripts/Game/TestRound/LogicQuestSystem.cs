using UnityEngine;
using UnityEngine.UI;
public class LogicQuestSystem : MonoBehaviour
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] QuestCaseData questCaseData;
    [SerializeField] Button[] btnCardSelects;
    void Awake()
    {
        questCaseData = FindObjectOfType<QuestCaseData>();
        animationsManager = FindObjectOfType<AnimationsManager>();
        BtnCardsOnclick();
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
            case 0: animationsManager.SetAnimations(questCaseData._idButton[0], 0, "cardSelect1Move"); btnCardSelects[0].enabled = false; break;
            case 1: animationsManager.SetAnimations(questCaseData._idButton[1], 1, "cardSelect2Move"); btnCardSelects[1].enabled = false; break;
            case 2: animationsManager.SetAnimations(questCaseData._idButton[2], 2, "cardSelect3Move"); btnCardSelects[2].enabled = false; break;
            default: ResetUCS(); break;
        }
    }
    public void ResetUCS()
    {
        animationsManager.BtnLogicFalse(); btnCardSelects[0].enabled = true; btnCardSelects[1].enabled = true; btnCardSelects[2].enabled = true;
    }
}