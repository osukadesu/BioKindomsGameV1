using UnityEngine;
public class QuestCaseFungi : MonoBehaviour
{
    [SerializeField] QuestCaseData questCaseData;
    void Awake() => questCaseData = FindObjectOfType<QuestCaseData>();
    public void SetFungi1(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 10, 11, 10, 12, 11, 10, 12 },
            1 => new int[] { 10, 10, 12, 11, 10, 12, 11 },
            2 => new int[] { 10, 12, 11, 10, 12, 11, 10 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi2(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 11, 11, 10, 13, 11, 10, 13 },
            1 => new int[] { 11, 13, 11, 10, 13, 11, 10 },
            2 => new int[] { 11, 10, 13, 11, 10, 13, 11 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi3(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 12, 11, 14, 12, 11, 14, 12 },
            1 => new int[] { 12, 12, 11, 14, 12, 11, 14 },
            2 => new int[] { 12, 14, 12, 11, 14, 12, 11 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi4(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 13, 12, 13, 14, 12, 13, 14 },
            1 => new int[] { 13, 13, 12, 14, 13, 12, 14 },
            2 => new int[] { 13, 12, 14, 13, 12, 14, 13 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetFungi5(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 14, 14, 13, 12, 14, 13, 12 },
            1 => new int[] { 14, 12, 14, 13, 12, 14, 13 },
            2 => new int[] { 14, 13, 12, 14, 13, 12, 14 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
}