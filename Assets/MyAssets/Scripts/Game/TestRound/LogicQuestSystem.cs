using UnityEngine;
using UnityEngine.UI;
public class LogicQuestSystem : MonoBehaviour
{
    [SerializeField] AnimationsManager animationsManager;
    [SerializeField] CompareSystem compareSystem;
    [SerializeField] Button[] btnCardSelects;
    void Awake()
    {
        compareSystem = FindObjectOfType<CompareSystem>();
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
        if (!compareSystem._gameFinished)
        {
            switch (btnCardValue)
            {
                case 0: animationsManager.SetAnimations(0, "cardSelect1Move"); btnCardSelects[0].enabled = false; break;
                case 1: animationsManager.SetAnimations(1, "cardSelect2Move"); btnCardSelects[1].enabled = false; break;
                case 2: animationsManager.SetAnimations(2, "cardSelect3Move"); btnCardSelects[2].enabled = false; break;
                default: ResetUCS(); break;
            }
        }
    }
    public void ResetUCS()
    {
        animationsManager.BtnLogicFalse(); btnCardSelects[0].enabled = true; btnCardSelects[1].enabled = true; btnCardSelects[2].enabled = true;
    }
}