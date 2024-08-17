using System.Collections.Generic;
using UnityEngine;
public class QuestCaseAnimal : MonoBehaviour
{
    [SerializeField] QuestCaseData questCaseData;
    void Awake()
    {
        questCaseData = FindObjectOfType<QuestCaseData>();
    }
    public void SetAnimal1(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 0, 0, 1, 2, 0, 1, 2 } },
            { 1, new int[] { 0, 1, 2, 0, 1, 2, 0 } },
            { 2, new int[] { 0, 2, 0, 1, 2, 0, 1 } },
            { 3, new int[] { 0, 0, 2, 1, 0, 2, 1 } },
            { 4, new int[] { 0, 1, 0, 2, 1, 0, 2 } },
        };
        if (dataCases.TryGetValue(_value, out int[] values))
        {
            questCaseData.SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
    public void SetAnimal2(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 1, 2, 1, 0, 2, 1, 0 } },
            { 1, new int[] { 1, 0, 1, 2, 0, 1, 2 } },
            { 2, new int[] { 1, 1, 2, 0, 1, 2, 0 } },
            { 3, new int[] { 1, 2, 0, 1, 2, 0, 1 } },
            { 4, new int[] { 1, 0, 2, 1, 0, 2, 1 } },
        };
        if (dataCases.TryGetValue(_value, out int[] values))
        {
            questCaseData.SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
    public void SetAnimal3(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 2, 1, 0, 2, 1, 0, 2 } },
            { 1, new int[] { 2, 2, 1, 0, 2, 1, 0 } },
            { 2, new int[] { 2, 0, 1, 2, 0, 1, 2 } },
            { 3, new int[] { 2, 1, 2, 0, 1, 2, 0 } },
            { 4, new int[] { 2, 2, 0, 1, 2, 0, 1 } },
        };
        if (dataCases.TryGetValue(_value, out int[] values))
        {
            questCaseData.SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
    public void SetAnimal4(int _value)
    {
        var animalCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 3, 3, 2, 1, 3, 2, 1 } },
            { 1, new int[] { 3, 1, 3, 2, 1, 3, 2 } },
            { 2, new int[] { 3, 2, 1, 3, 2, 1, 3 } },
            { 3, new int[] { 3, 3, 1, 2, 3, 1, 2 } },
            { 4, new int[] { 3, 1, 2, 3, 1, 2, 3 } },
        };
        if (animalCases.TryGetValue(_value, out int[] values))
        {
            questCaseData.SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
    public void SetAnimal5(int _value)
    {
        var animalCases = new Dictionary<int, int[]>
        {
            { 0, new int[] { 4, 3, 4, 1, 3, 4, 1 } },
            { 1, new int[] { 4, 4, 3, 1, 4, 3, 1 } },
            { 2, new int[] { 4, 1, 4, 3, 1, 4, 3 } },
            { 3, new int[] { 4, 3, 1, 4, 3, 1, 4 } },
            { 4, new int[] { 4, 4, 1, 3, 4, 1, 3 } },
        };
        if (animalCases.TryGetValue(_value, out int[] values))
        {
            questCaseData.SetDataCases(values[0], values[1], values[2], values[3], values[4], values[5], values[6]);
        }
        else
        {
            Debug.LogError("Quest error!");
        }
    }
}
/*
void VegetalQuest(int _value)
    {
        var dataCases = new Dictionary<int, int[]>
        {
            { 5, new int[] { 5, 6, 7, 5, 6, 7, 5 } },
            { 6, new int[] { 6, 9, 6, 5, 9, 6, 5 } },
            { 7, new int[] { 7, 6, 7, 8, 6, 7, 8 } },
            { 8, new int[] { 8, 8, 7, 5, 8, 7, 5 } },
            { 9, new int[] { 9, 8, 7, 9, 8, 7, 9 } },
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
*/