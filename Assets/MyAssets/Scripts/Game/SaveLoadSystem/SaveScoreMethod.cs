using UnityEngine;
public class SaveScoreMethod : MonoBehaviour
{
    [SerializeField] CompareState compareState;
    [SerializeField] QuestLevel questLevel;
    void Awake()
    {
        compareState = FindObjectOfType<CompareState>();
        questLevel = FindObjectOfType<QuestLevel>();
    }
    public void SavingScore()
    {
        SaveScoreData.SaveScore(compareState, questLevel);
        Debug.Log("score saved");
    }
}