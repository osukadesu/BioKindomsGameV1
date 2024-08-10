[System.Serializable]
public class ScoreData
{
    public int scoreA, scoreV, scoreF, scoreP, scoreM, finalScore;
    public ScoreData(CompareState compareState)
    {
        scoreA = compareState._scoreA;
        scoreV = compareState._scoreV;
        scoreF = compareState._scoreF;
        scoreP = compareState._scoreP;
        scoreM = compareState._scoreM;
        finalScore = (scoreA + scoreV + scoreF + scoreP + scoreM) / 5;
    }
}