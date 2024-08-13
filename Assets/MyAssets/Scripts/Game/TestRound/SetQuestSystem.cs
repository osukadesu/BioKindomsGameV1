using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
public class SetQuestSystem : MonoBehaviour
{
    [SerializeField] AnswerButtonData[] answerButtonDatas;
    [SerializeField] QuestLevelData questLevelDatas;
    [SerializeField] Text textQuest;
    [SerializeField] Image[] imageItem;
    [SerializeField] Image imageKindom;
    [SerializeField] int random, lastRandom = -1;
    [SerializeField] int[] idButton, idQuest;
    public int _myRandom { get => random; set => random = value; }
    public int[] _idQuest { get => idQuest; set => idQuest = value; }
    public int[] _idButton { get => idButton; set => idButton = value; }
    void SetRandom(int _value)
    {
        Action action = _value switch
        {
            0 => () => random = NotRepiteRandom(0, 5),
            1 => () => random = NotRepiteRandom(5, 10),
            _ => () => Debug.Log("Case default!")
        };
        action();
    }
    int NotRepiteRandom(int rangeInit, int rangeEnd)
    {
        int newRandom;
        do
        {
            newRandom = Random.Range(rangeInit, rangeEnd);
        } while (newRandom == lastRandom);

        lastRandom = newRandom;
        return newRandom;
    }
    public void SetCase(int _value)
    {
        SetRandom(_value);
        Debug.Log("Quest: " + random);
        Action action = _value switch
        {
            0 => () => AnimalQuest(random),
            1 => () => VegetalQuest(random),
            _ => () => Debug.Log("Case default!")
        };
        action();
    }
    void AnimalQuest(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 0, 0, 1, 2, 0, 1, 2 } },
            { 1, new int[] { 1, 2, 0, 1, 2, 0, 1 } },
            { 2, new int[] { 2, 0, 2, 1, 0, 2, 1 } },
            { 3, new int[] { 3, 3, 1, 2, 3, 1, 2 } },
            { 4, new int[] { 4, 1, 4, 3, 1, 4, 3 } }
        };
        if (dataCases.TryGetValue(_value, out int[] values))
        {
            SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
    void VegetalQuest(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 5, new int[] { 5, 6, 7, 5, 6, 7, 5 } },
            { 6, new int[] { 6, 9, 6, 5, 9, 6, 5 } },
            { 7, new int[] { 7, 6, 7, 8, 6, 7, 8 } },
            { 8, new int[] { 8, 8, 7, 5, 8, 7, 5 } },
            { 9, new int[] { 9, 8, 7, 9, 8, 7, 9 } }
        };
        if (dataCases.TryGetValue(_value, out int[] values))
        {
            SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
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