using UnityEngine;
public class LoadLevelSelect : MonoBehaviour
{
    [SerializeField] LevelSelect levelSelect;
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
    }
    protected internal void GoLoadLevelSelect()
    {
        PlayerData playerData = SaveAndLoadManager.LoadLevel();
        SettingLevelsSelect(playerData);
    }
    protected internal void SettingLevelsSelect(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
        levelSelect.ShowLevel(levelSelect.currentLevel);
        Debug.Log("LevelSelect: " + levelSelect.currentLevel);
    }
}