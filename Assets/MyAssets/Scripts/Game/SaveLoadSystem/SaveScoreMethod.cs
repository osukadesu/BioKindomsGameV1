using UnityEngine;

public class SaveScoreMethod : MonoBehaviour
{
    [SerializeField] CompareState compareState;
    public void SavingScore()
    {
        SaveScoreData.SaveScore(compareState);
        Debug.Log("score saved");
    }
}