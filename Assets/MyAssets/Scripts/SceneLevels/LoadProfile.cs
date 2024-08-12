using UnityEngine;
using UnityEngine.UI;
public class LoadProfile : MonoBehaviour
{
    [SerializeField] LoadProfileSingleton loadProfileSingleton;
    [SerializeField] ScoreAnimations[] scoreAnimations;
    [SerializeField] ProfileSystem levelSelect;
    [SerializeField] Text txtScoreA, txtScoreV, txtScoreF, txtScoreP, txtScoreM, txtFinalScore;
    public int[] num = new int[5];
    public int finalScore;
    void Awake()
    {
        levelSelect = FindObjectOfType<ProfileSystem>();
        loadProfileSingleton = FindObjectOfType<LoadProfileSingleton>();
    }
    protected internal void GoNewProfile()
    {
        levelSelect.currentLevel = 1;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        txtScoreA.text = num[0].ToString();
        txtScoreV.text = num[1].ToString();
        txtScoreF.text = num[2].ToString();
        txtScoreP.text = num[3].ToString();
        txtScoreM.text = num[4].ToString();
        txtFinalScore.text = FinalScore().ToString();
        scoreAnimations[0].SwitchAnimations(num[0]);
        scoreAnimations[1].SwitchAnimations(num[1]);
        scoreAnimations[2].SwitchAnimations(num[2]);
        scoreAnimations[3].SwitchAnimations(num[3]);
        scoreAnimations[4].SwitchAnimations(num[4]);
        scoreAnimations[5].SwitchAnimations(finalScore);
    }
    int FinalScore()
    {
        return finalScore = (num[0] + num[1] + num[2] + num[3] + num[4]) / 5;
    }
    protected internal void GoLoadProfile()
    {
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        ScoreData scoreData = SaveScoreData.LoadScore();
        SettingLevelsSelect(playerData);
        SettScore(scoreData);
    }
    protected internal void SettingLevelsSelect(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        Debug.Log("LevelSelect: " + levelSelect.currentLevel);
    }
    public void SettScore(ScoreData scoreData)
    {
        for (int i = 0; i < 5; i++)
        {
            num[i] = scoreData.score[i];
            loadProfileSingleton._num[i] = scoreData.score[i];
        }
        finalScore = scoreData.finalScore;
        txtScoreA.text = num[0].ToString();
        txtScoreV.text = num[1].ToString();
        txtScoreF.text = num[2].ToString();
        txtScoreP.text = num[3].ToString();
        txtScoreM.text = num[4].ToString();
        txtFinalScore.text = finalScore.ToString();
        scoreAnimations[0].SwitchAnimations(num[0]);
        scoreAnimations[1].SwitchAnimations(num[1]);
        scoreAnimations[2].SwitchAnimations(num[2]);
        scoreAnimations[3].SwitchAnimations(num[3]);
        scoreAnimations[4].SwitchAnimations(num[4]);
        scoreAnimations[5].SwitchAnimations(finalScore);
        Debug.Log("score load: " + scoreData.score[0] + " " + scoreData.score[1] + " " + scoreData.score[2] + " " + scoreData.score[3] + " " + scoreData.score[4]);
    }
}