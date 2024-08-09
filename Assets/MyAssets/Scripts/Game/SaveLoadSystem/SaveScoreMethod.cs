using UnityEngine;
public class SaveScoreMethod : MonoBehaviour
{
    [SerializeField] CompareState compareState;
    [SerializeField] QuestLevel questLevel;
    public void SavingScore()
    {
        SaveScoreData.SaveScore(compareState);
        SaveAndLoadManager.SaveQuest(questLevel);
        Debug.Log("score saved");
    }
}