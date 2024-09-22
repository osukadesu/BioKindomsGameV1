using System;
using System.IO;
using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] QuestGameObjects questGameObjects;
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] LevelDisplay levelDisplay;
    [SerializeField] EstanteColChecked estanteColChecked;
    [SerializeField] ItemObject[] itemObjects;
    public InventoryItemDataV2[] inventoryItemDataV2;
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
            >= 1 and <= 11 => () => Debug.Log("Not load singleton quest!"),
            _ => () => GoLoadSingletonQuest(),
        };
        action();
    }
    public void GoNewGame()
    {
        levelSystemV2.CurrentLevel = 1;
        levelDisplay.ShowLevel(levelSystemV2.CurrentLevel);
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = false;
        }
        for (int i = 0; i < 5; i++)
        {
            GeneralSingleton.generalSingleton.endQuest[i] = false;
        }
        GeneralSingleton.generalSingleton.CaseValue = -1;
        estanteColChecked.EstantesInitial();
    }
    public void GoLoadGame()
    {
        PlayerData playerData = SaveAndLoadManager.LoadGame();
        SettingLevels(playerData);
        SettingKingdom(playerData);
        CheckingKingdom(playerData);
        //questGameObjects.DestroyObjects(levelSystemV2.CurrentLevel);
        estanteColChecked.EstanteBool("estanteLoad");
    }
    void GoLoadSingletonQuest()
    {
        ScoreData scoreData = SaveScoreData.LoadScore();
        SetQuestSingleton(scoreData);
    }
    void SettingLevels(PlayerData playerData)
    {
        levelSystemV2.CurrentLevel = playerData.currentLevelData;
        levelDisplay.ShowLevel(levelSystemV2.CurrentLevel);
    }
    void SettingKingdom(PlayerData playerData)
    {
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.kingdoms[i];
        }
    }
    void CheckingKingdom(PlayerData playerData)
    {
        for (int i = 0; i < itemObjects.Length; i++)
        {
            if (playerData.kingdoms[i]) { itemObjects[i].OnHandlePickUpLoad(); }
        }
    }
    void SetQuestSingleton(ScoreData scoreData)
    {
        for (int i = 0; i < 5; i++)
        {
            GeneralSingleton.generalSingleton.endQuest[i] = scoreData.endQuest[i];
        }
        GeneralSingleton.generalSingleton.CaseValue = scoreData._caseValue;
    }
}