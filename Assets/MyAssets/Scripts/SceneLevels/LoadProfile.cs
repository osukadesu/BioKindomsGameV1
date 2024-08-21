using System;
using UnityEngine;
using UnityEngine.UI;
public class LoadProfile : MonoBehaviour
{
    [SerializeField] ScoreAnimations[] scoreAnimations;
    [SerializeField] ProfileSystem levelSelect;
    [SerializeField] Text txtFinalScore;
    [SerializeField] Text[] txtScore;
    public int[] num = new int[5];
    public int finalScore;
    void Awake()
    {
        levelSelect = FindObjectOfType<ProfileSystem>();
    }
    protected internal void GoNewProfile()
    {
        for (int i = 0; i < txtScore.Length; i++)
        {
            txtScore[i].text = num[i].ToString();
        }
        txtFinalScore.text = FinalScore().ToString();
        for (int i = 0; i < scoreAnimations.Length; i++)
        {
            int scoreValue = i < 5 ? num[i] : finalScore;
            scoreAnimations[i].SwitchAnimations(scoreValue);
        }
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        SettingLevelsSelect(playerData, false);
    }
    int FinalScore()
    {
        return finalScore = (num[0] + num[1] + num[2] + num[3] + num[4]) / 5;
    }
    protected internal void GoLoadProfile()
    {
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        ScoreData scoreData = SaveScoreData.LoadScore();
        SettingLevelsSelect(playerData, true);
        SettScore(scoreData);
    }
    protected internal void SettingLevelsSelect(PlayerData playerData, bool isLoad)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
        levelSelect.ShowLevel(levelSelect.currentLevel, isLoad);
    }
    public void SettScore(ScoreData scoreData)
    {
        for (int i = 0; i < 5; i++)
        {
            num[i] = scoreData.score[i];
            GeneralSingleton.generalSingleton._num[i] = scoreData.score[i];
        }
        for (int i = 0; i < txtScore.Length; i++)
        {
            txtScore[i].text = num[i].ToString();
        }
        finalScore = scoreData.finalScore;
        txtFinalScore.text = finalScore.ToString();
        for (int i = 0; i < scoreAnimations.Length; i++)
        {
            int scoreValue = i < 5 ? num[i] : finalScore;
            scoreAnimations[i].SwitchAnimations(scoreValue);
        }
        Debug.Log("score load: " + scoreData.score[0] + " " + scoreData.score[1] + " " + scoreData.score[2] + " " + scoreData.score[3] + " " + scoreData.score[4]);
    }
}