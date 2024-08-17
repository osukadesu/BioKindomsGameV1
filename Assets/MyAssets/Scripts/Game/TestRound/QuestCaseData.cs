using UnityEngine;
using UnityEngine.UI;
public class QuestCaseData : MonoBehaviour
{
    [SerializeField] AnswerButtonData[] answerButtonDatas;
    [SerializeField] QuestLevelData questLevelDatas;
    [SerializeField] Text textQuest;
    [SerializeField] Image[] imageItem;
    [SerializeField] Image imageKindom;
    [SerializeField] int[] idButton, idQuest;
    public int[] _idQuest { get => idQuest; set => idQuest = value; }
    public int[] _idButton { get => idButton; set => idButton = value; }
    public void SetDataCases(int _idQuest, int _idAnswer1, int _idAnswer2, int _idAnswer3, int _idImgA1, int _idImgA2, int _idImgA3)
    {
        idQuest[_idQuest] = questLevelDatas.idQuest[_idQuest];
        textQuest.text = questLevelDatas.texQuest[_idQuest];
        imageKindom.sprite = questLevelDatas.imageKindom[0];
        int[] answers = { _idAnswer1, _idAnswer2, _idAnswer3 };
        int[] images = { _idImgA1, _idImgA2, _idImgA3 };
        for (int i = 0; i < 3; i++)
        {
            idButton[i] = answerButtonDatas[i].idAnswer = answers[i];
            imageItem[i].sprite = answerButtonDatas[i].imageItem[images[i]];
        }
        GeneralSingleton.generalSingleton.MouseUnLock();
    }
}