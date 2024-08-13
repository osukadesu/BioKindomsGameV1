[System.Serializable]
public class ScoreData
{
    public int[] score = new int[5];
    public int finalScore;
    public bool _endQuestV2;
    public int _caseValueV2;
    public ScoreData(CompareState compareState, QuestLevel questLevel)
    {
        for (int i = 0; i < 5; i++)
        {
            int increment = i;
            score[i] = compareState._score[increment];
        }
        finalScore = (score[0] + score[1] + score[2] + score[3] + score[4]) / 5;
        MappingQuestSingleton(questLevel);
    }
    void MappingQuestSingleton(QuestLevel questLevel)
    {
        _endQuestV2 = questLevel._endQuest;
        _caseValueV2 = questLevel.CaseValue;
    }
}