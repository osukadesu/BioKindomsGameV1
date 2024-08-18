using UnityEngine;

public class QuestCaseFungi : MonoBehaviour
{
    //Changes values...
    [SerializeField] QuestCaseData questCaseData;
    void Awake()
    {
        questCaseData = FindObjectOfType<QuestCaseData>();
    }
    public void SetFungi1(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 10, 5, 6, 7, 5, 6, 7 },
            1 => new int[] { 10, 6, 7, 5, 6, 7, 5 },
            2 => new int[] { 10, 7, 5, 6, 7, 5, 6 },
            3 => new int[] { 10, 7, 6, 5, 7, 6, 5 },
            4 => new int[] { 10, 5, 7, 6, 5, 7, 6 },
            5 => new int[] { 10, 6, 5, 7, 6, 5, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi2(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 11, 5, 6, 9, 5, 6, 9 },
            1 => new int[] { 11, 6, 9, 5, 6, 9, 5 },
            2 => new int[] { 11, 9, 5, 6, 9, 9, 6 },
            3 => new int[] { 11, 9, 6, 5, 9, 6, 5 },
            4 => new int[] { 11, 5, 9, 6, 5, 9, 6 },
            5 => new int[] { 11, 6, 5, 9, 6, 5, 9 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi3(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 12, 6, 7, 8, 6, 7, 8 },
            1 => new int[] { 12, 7, 8, 6, 7, 8, 6 },
            2 => new int[] { 12, 8, 6, 7, 8, 6, 7 },
            3 => new int[] { 12, 8, 7, 6, 8, 7, 6 },
            4 => new int[] { 12, 6, 8, 7, 6, 8, 7 },
            5 => new int[] { 12, 7, 6, 8, 7, 6, 8 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi4(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 13, 8, 7, 5, 8, 7, 5 },
            1 => new int[] { 13, 7, 8, 5, 7, 8, 5 },
            2 => new int[] { 13, 8, 5, 7, 8, 5, 7 },
            3 => new int[] { 13, 5, 8, 7, 5, 8, 7 },
            4 => new int[] { 13, 5, 7, 8, 5, 7, 8 },
            5 => new int[] { 13, 7, 5, 8, 7, 5, 8 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi5(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 14, 7, 8, 9, 7, 8, 9 },
            1 => new int[] { 14, 9, 8, 7, 9, 8, 7 },
            2 => new int[] { 14, 8, 9, 8, 8, 9, 7 },
            3 => new int[] { 14, 7, 9, 8, 7, 9, 8 },
            4 => new int[] { 14, 8, 7, 9, 8, 7, 9 },
            5 => new int[] { 14, 9, 7, 8, 9, 7, 8 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
}