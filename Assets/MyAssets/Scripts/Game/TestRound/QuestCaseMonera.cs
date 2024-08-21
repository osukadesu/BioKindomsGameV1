using UnityEngine;
public class QuestCaseMonera : MonoBehaviour
{
    [SerializeField] QuestCaseData questCaseData;
    void Awake()
    {
        questCaseData = FindObjectOfType<QuestCaseData>();
    }
    public void SetMonera1(int _value)
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
    public void SetMonera2(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 6, 5, 6, 9, 5, 6, 9 },
            1 => new int[] { 6, 6, 9, 5, 6, 9, 5 },
            2 => new int[] { 6, 9, 5, 6, 9, 9, 6 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetMonera3(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 7, 6, 7, 8, 6, 7, 8 },
            1 => new int[] { 7, 7, 8, 6, 7, 8, 6 },
            2 => new int[] { 7, 8, 6, 7, 8, 6, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetMonera4(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 8, 8, 7, 5, 8, 7, 5 },
            1 => new int[] { 8, 7, 8, 5, 7, 8, 5 },
            2 => new int[] { 8, 8, 5, 7, 8, 5, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetMonera5(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 9, 7, 8, 9, 7, 8, 9 },
            1 => new int[] { 9, 9, 8, 7, 9, 8, 7 },
            2 => new int[] { 9, 8, 9, 8, 8, 9, 7 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
}
