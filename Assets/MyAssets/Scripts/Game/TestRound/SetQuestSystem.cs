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
    public void SetCase(int _value)
    {
        random = Random.Range(0, 2);
        Debug.Log("Quest: " + random);
        switch (_value)
        {
            case 0:
                AnimalQuest(random);
                break;
        }
    }
    void AnimalQuest(int _value)
    {
        switch (_value)
        {
            case 0:
                SetDataCases(0, 0, 0, 0, 1, 2);
                break;
            case 1:
                SetDataCases(1, 1, 0, 0, 2, 3);
                break;
            /*
              case 2:
                  SetDataCases(0, 0, 0, 0, 1, 2, 0, 1, 2);
                  break;
              case 3:
                  SetDataCases(0, 0, 0, 0, 1, 2, 0, 1, 2);
                  break;
              case 4:
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
        imageKindom.sprite = questLevelDatas.imageKindom[_imageQuest];
        idButton[0] = answerButtonDatas[0].idAnswer = 0;
        imageItem[0].sprite = answerButtonDatas[0].imageItem[_idImgA1];
        idButton[1] = answerButtonDatas[1].idAnswer = 1;
        imageItem[1].sprite = answerButtonDatas[1].imageItem[_idImgA2];
        idButton[2] = answerButtonDatas[2].idAnswer = 2;
        imageItem[2].sprite = answerButtonDatas[2].imageItem[_idImgA3];
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}