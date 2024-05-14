using UnityEngine;
using UnityEngine.UI;
public class LoadLevelSelect : MonoBehaviour
{
    [SerializeField] LevelSelect levelSelect;
    [SerializeField] Text txtScoreValue;
    void Awake()
    {
        levelSelect = FindObjectOfType<LevelSelect>();
    }
    protected internal void GoNewGameAndLevel()
    {
        levelSelect.currentLevel = 1;
        levelSelect.ShowLevel(levelSelect.currentLevel);
    }
    protected internal void GoLoadGame()
    {
        PlayerData playerData = SaveAndLoadManager.LoadDataGame();
        SettingLevelsSelect(playerData);
        ScoreData scoreData = SaveScoreData.LoadScore();
        txtScoreValue.text = scoreData.scoreValue.ToString();
        Debug.Log("score load: " + scoreData.scoreValue);

    }
    protected internal void GoLoadLevelSelect()
    {
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        SettingLevelsSelect(playerData);
        ScoreData scoreData = SaveScoreData.LoadScore();
        txtScoreValue.text = scoreData.scoreValue.ToString();
        Debug.Log("score load: " + scoreData.scoreValue);
    }
    protected internal void SettingLevelsSelect(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        Debug.Log("LevelSelect: " + levelSelect.currentLevel);
    }
}