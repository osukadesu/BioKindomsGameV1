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
        var values = _value switch
        {
            0 => new int[] { 0, 0, 1, 2, 0, 1, 2 },
            1 => new int[] { 0, 1, 2, 0, 1, 2, 0 },
            2 => new int[] { 0, 2, 0, 1, 2, 0, 1 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetAnimal2(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 1, 1, 2, 0, 1, 2, 0 },
            1 => new int[] { 1, 2, 0, 1, 2, 0, 1 },
            2 => new int[] { 1, 0, 1, 2, 0, 1, 2 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetAnimal3(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 2, 2, 1, 0, 2, 1, 0 },
            1 => new int[] { 2, 1, 0, 2, 1, 0, 2 },
            2 => new int[] { 2, 0, 2, 1, 0, 2, 1 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetAnimal4(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 3, 3, 2, 1, 3, 2, 1 },
            1 => new int[] { 3, 2, 1, 3, 2, 1, 3 },
            2 => new int[] { 3, 1, 3, 2, 1, 3, 2 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
    public void SetAnimal5(int _value)
    {
        var values = _value switch
        {
            0 => new int[] { 4, 4, 1, 3, 4, 1, 3 },
            1 => new int[] { 4, 1, 3, 4, 1, 3, 4 },
            2 => new int[] { 4, 3, 4, 1, 3, 4, 1 },
            _ => null,
        };
        questCaseData.SetValues(values);
    }
}