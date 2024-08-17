[System.Serializable]
public class ScoreData
{
    public int[] score = new int[5];
    public int finalScore;
    public bool _endQuestV2;
    public int _caseValueV2;
    public ScoreData(CompareState compareState, GeneralSingleton generalSingleton)
    {
        for (int i = 0; i < 5; i++)
        {
            int increment = i;
            score[i] = compareState._score[increment];
        }
        finalScore = (score[0] + score[1] + score[2] + score[3] + score[4]) / 5;
        MappingQuestSingleton(generalSingleton);
    }
    void MappingQuestSingleton(GeneralSingleton generalSingleton)
    {
        _endQuestV2 = generalSingleton.endQuest;
        _caseValueV2 = generalSingleton.CaseValue;
    }
}