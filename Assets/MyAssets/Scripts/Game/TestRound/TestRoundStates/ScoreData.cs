[System.Serializable]
public class ScoreData
{
    public int scoreValue;
    public ScoreData(CompareState compareState)
    {
        scoreValue = compareState._score;
    }
}