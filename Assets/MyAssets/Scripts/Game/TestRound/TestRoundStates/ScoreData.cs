[System.Serializable]
public class ScoreData
{
    public int[] score = new int[5];
    public int finalScore;
    public ScoreData(CompareState compareState)
    {
        for (int i = 0; i < 5; i++)
        {
            int increment = i;
            score[i] = compareState._score[increment];
        }
        finalScore = (score[0] + score[1] + score[2] + score[3] + score[4]) / 5;
    }
}