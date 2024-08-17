using UnityEngine;
public class SaveScoreMethod : MonoBehaviour
{
    [SerializeField] CompareState compareState;
    void Awake()
    {
        compareState = FindObjectOfType<CompareState>();
    }
    public void SavingScore()
    {
        SaveScoreData.SaveScore(compareState, GeneralSingleton.generalSingleton);
    }
}