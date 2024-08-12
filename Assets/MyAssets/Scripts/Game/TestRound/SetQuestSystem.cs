using UnityEngine;
using UnityEngine.UI;
public class SetQuestSystem : MonoBehaviour
{
    [SerializeField] AnswerButtonData[] answerButtonDatas;
    [SerializeField] QuestLevelData questLevelDatas;
    [SerializeField] Text textQuest;
    [SerializeField] Image[] imageItem;
    [SerializeField] Image imageKindom;
    [SerializeField] int random;
    [SerializeField] int[] idButton, idQuest;
    public int _myRandom { get => random; set => random = value; }
    public int[] _idQuest { get => idQuest; set => idQuest = value; }
    public int[] _idButton { get => idButton; set => idButton = value; }
    void SetRandom(int _value)
    {
        switch (_value)
        {
            case 0:
                random = Random.Range(0, 5);
                break;
            case 1:
                random = Random.Range(5, 10);
                break;
        }
    }
    public void SetCase(int _value)
    {
        SetRandom(_value);
        Debug.Log("Quest: " + random);
        switch (_value)
        {
            case 0:
                AnimalQuest(random);
                break;
            case 1:
                VegetalQuest(random);
                break;
        }
    }
    void AnimalQuest(int _value)
    {
        switch (_value)
        {
            case 0:
                SetDataCases(0, 0, 1, 2, 0, 1, 2);
                break;
            case 1:
                SetDataCases(1, 2, 0, 1, 2, 0, 1);
                break;
            case 2:
                SetDataCases(2, 0, 2, 1, 0, 2, 1);
                break;
            case 3:
                SetDataCases(3, 3, 1, 2, 3, 1, 2);
                break;
            case 4:
                SetDataCases(4, 1, 4, 3, 1, 4, 3);
                break;
            default:
                Debug.LogError("Quest error!");
                break;
        }
    }
    void VegetalQuest(int _value)
    {
        switch (_value)
        {
            case 5:
                SetDataCases(5, 6, 7, 5, 6, 7, 5);
                break;
            case 6:
                SetDataCases(6, 9, 6, 5, 9, 6, 5);
                break;
            case 7:
                SetDataCases(7, 6, 7, 8, 6, 7, 8);
                break;
            case 8:
                SetDataCases(8, 8, 7, 5, 8, 7, 5);
                break;
            case 9:
                SetDataCases(9, 8, 7, 9, 8, 7, 9);
                break;
            default:
                Debug.LogError("Quest error!");
                break;
        }
    }
    void SetDataCases(int _idQuest, int _idAnswer1, int _idAnswer2, int _idAnswer3, int _idImgA1, int _idImgA2, int _idImgA3)
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}