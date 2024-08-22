using System;
using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] QuestGameObjects questGameObjects;
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] LevelDisplay levelDisplay;
    [SerializeField] EstanteColChecked estanteColChecked;
    [SerializeField] protected internal ItemObject[] itemObjects;
    [SerializeField] protected internal InventoryItemDataV2[] inventoryItemDataV2;
    void Awake()
    {
        questGameObjects = FindObjectOfType<QuestGameObjects>();
        levelSystemV2 = FindObjectOfType<LevelSystem>();
        levelDisplay = FindObjectOfType<LevelDisplay>();
        estanteColChecked = FindObjectOfType<EstanteColChecked>();
    }
    public void LoadSingletonQuest(int _level)
    {
        Action action = _level switch
        {
            12 or 13 or 14 or 15 or 16 or 17 or 18 or 19 or 20 or 21
            or 22 or 23 or 24 or 25
            => () => GoLoadSingletonQuest(),
            _ => () => Debug.Log("Case default!"),
        };
        action();
    }
    protected internal void GoNewGame()
    {
        levelSystemV2.CurrentLevel = 1;
        levelDisplay.ShowLevel(levelSystemV2.CurrentLevel);
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = false;
        }
        GeneralSingleton.generalSingleton.endQuest = false;
        GeneralSingleton.generalSingleton.CaseValue = -1;
        estanteColChecked.EstantesInitial();
    }
    protected internal void GoLoadGame()
    {
        PlayerData playerData = SaveAndLoadManager.LoadGame();
        SettingLevels(playerData);
        SettingKingdom(playerData);
        CheckingKingdom(playerData);
        SetDestroyObject(levelSystemV2.CurrentLevel);
        estanteColChecked.EstanteBool("estanteLoad");
    }
    protected internal void GoLoadSingletonQuest()
    {
        ScoreData scoreData = SaveScoreData.LoadScore();
        SetQuestSingleton(scoreData);
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSystemV2.CurrentLevel = playerData.currentLevelData;
        levelDisplay.ShowLevel(levelSystemV2.CurrentLevel);
    }
    protected internal void SettingKingdom(PlayerData playerData)
    {
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.kingdoms[i];
        }
    }
    protected internal void CheckingKingdom(PlayerData playerData)
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (playerData.kingdoms[i]) { itemObjects[i].OnHandlePickUpLoad(); }
        }
    }
    protected internal void SetQuestSingleton(ScoreData scoreData)
    {
        GeneralSingleton.generalSingleton.endQuest = scoreData._endQuestV2;
        GeneralSingleton.generalSingleton.CaseValue = scoreData._caseValueV2;
    }
    protected internal void SetDestroyObject(int _value)
    {
        Action action = _value switch
        {
            12 => () => questGameObjects.DestroyingObjects(0),
            _ => () => Debug.Log(" SetDestroyObject case default!"),
        };
        action();
    }
}