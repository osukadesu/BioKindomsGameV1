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
    public void SetCase(int _value)
    {
        random = Random.Range(0, 5);
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
    void SetDataCases(int _idQuest, int _idAnswer1, int _idAnswer2, int _idAnswer3, int _idImgA1, int _idImgA2, int _idImgA3)
    {
        idQuest[_idQuest] = questLevelDatas.idQuest[_idQuest];
        textQuest.text = questLevelDatas.texQuest[_idQuest];
        imageKindom.sprite = questLevelDatas.imageKindom[0];
        idButton[0] = answerButtonDatas[0].idAnswer = _idAnswer1;
        imageItem[0].sprite = answerButtonDatas[0].imageItem[_idImgA1];
        idButton[1] = answerButtonDatas[1].idAnswer = _idAnswer2;
        imageItem[1].sprite = answerButtonDatas[1].imageItem[_idImgA2];
        idButton[2] = answerButtonDatas[2].idAnswer = _idAnswer3;
        imageItem[2].sprite = answerButtonDatas[2].imageItem[_idImgA3];
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}