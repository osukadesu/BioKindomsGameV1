using System;
using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] QuestGameObjects questGameObjects;
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] EstanteColChecked estanteColChecked;
    [SerializeField] protected internal ItemObject[] itemObjects;
    [SerializeField] protected internal InventoryItemDataV2[] inventoryItemDataV2;
    void Awake()
    {
        questGameObjects = FindObjectOfType<QuestGameObjects>();
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
        estanteColChecked = FindObjectOfType<EstanteColChecked>();
    }
    protected internal void GoNewGame()
    {
        levelSystemV2.CurrentLevel = 1;
        showLevelCaseV2.ShowLevel(levelSystemV2.CurrentLevel);
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
        showLevelCaseV2.ShowLevel(levelSystemV2.CurrentLevel);
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