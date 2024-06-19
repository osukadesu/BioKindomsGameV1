using UnityEngine;
using UnityEngine.UI;
public class LoadProfile : MonoBehaviour
{
    [SerializeField] ProfileSystem levelSelect;
    [SerializeField] Text txtScoreA, txtScoreV, txtScoreF, txtScoreP, txtScoreM;
    int num = 0;
    void Awake()
    {
        levelSelect = FindObjectOfType<ProfileSystem>();
    }
    protected internal void GoNewProfile()
    {
        levelSelect.currentLevel = 1;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        txtScoreA.text = num.ToString();
        txtScoreV.text = num.ToString();
        txtScoreF.text = num.ToString();
        txtScoreP.text = num.ToString();
        txtScoreM.text = num.ToString();
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
        txtScoreA.text = scoreData.scoreValue.ToString();
        txtScoreV.text = scoreData.scoreValue.ToString();
        txtScoreF.text = scoreData.scoreValue.ToString();
        txtScoreP.text = scoreData.scoreValue.ToString();
        txtScoreM.text = scoreData.scoreValue.ToString();
        Debug.Log("score load: " + scoreData.scoreValue);
    }
}