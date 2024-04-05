using UnityEngine;
public class QuestLevel : MonoBehaviour
{
    public static QuestLevel questLevel;
    [SerializeField] int caseValue;
    public int CaseValue { get => caseValue; set => caseValue = value; }
    void Awake()
    {
        Singleton();
    }
    void Singleton()
    {
        if (questLevel == null)
        {
            questLevel = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    protected internal void ChangeQuestLevel()
    {
        caseValue++;
    }
}