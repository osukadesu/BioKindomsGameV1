using UnityEngine;

public class QuestCaseVegetal : MonoBehaviour
{
    [SerializeField] QuestCaseData questCaseData;
    void Awake() => questCaseData = FindObjectOfType<QuestCaseData>();
    public void SetVegetal1(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 5, 5, 6, 7, 5, 6, 7 },
            1 => new int[] { 5, 6, 7, 5, 6, 7, 5 },
            2 => new int[] { 5, 7, 5, 6, 7, 5, 6 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetVegetal2(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 6, 5, 6, 9, 5, 6, 9 },
            1 => new int[] { 6, 6, 9, 5, 6, 9, 5 },
            2 => new int[] { 6, 9, 5, 6, 9, 5, 6 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetVegetal3(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 7, 5, 7, 8, 5, 7, 8 },
            1 => new int[] { 7, 7, 8, 5, 7, 8, 5 },
            2 => new int[] { 7, 8, 5, 7, 8, 5, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetVegetal4(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 8, 8, 7, 5, 8, 7, 5 },
            1 => new int[] { 8, 7, 5, 8, 7, 5, 8 },
            2 => new int[] { 8, 5, 8, 7, 5, 8, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetVegetal5(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 9, 5, 8, 9, 5, 8, 9 },
            1 => new int[] { 9, 9, 8, 5, 9, 8, 5 },
            2 => new int[] { 9, 8, 9, 8, 8, 9, 5 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
}