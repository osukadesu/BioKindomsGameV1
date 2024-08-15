using System;
using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] QuestLevel questLevel;
    [SerializeField] protected internal ItemObject[] IOA;
    [SerializeField] protected internal ItemObjectA2[] IOV;
    [SerializeField] protected internal InventoryUI inventoryUIA;
    [SerializeField] protected internal InventoryUIV inventoryUIV;
    [SerializeField] protected internal InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] Transform[] targetPlayerPosition;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        inventoryUIA = FindObjectOfType<InventoryUI>();
        inventoryUIV = FindObjectOfType<InventoryUIV>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    protected internal void GoNewGame()
    {
        Debug.Log("New Game!");
        SetInventoryUI();
        levelSystemV2.CurrentLevel = 1;
        showLevelCaseV2.ShowLevel(levelSystemV2.CurrentLevel);
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = false;
        }
        questLevel._endQuest = false;
        questLevel.CaseValue = -1;
    }
    protected internal void GoLoadGame()
    {
        Debug.Log("Game Loaded!");
        SetInventoryUI();
        PlayerData playerData = SaveAndLoadManager.LoadGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        CheckingAnimal(playerData);
        SettingVegetals(playerData);
        CheckingVegetal(playerData);
        SetDestroyObject(levelSystemV2.CurrentLevel);
    }
    protected internal void GoLoadSingletonQuest()
    {
        ScoreData scoreData = SaveScoreData.LoadScore();
        SetQuestSingleton(scoreData);
    }
    protected internal void SetInventoryUI()
    {
        InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUIA.OnUpdateInventory;
        InventorySystemV.instance2.OnInventoryChangedEventCallBack += inventoryUIV.OnUpdateInventory;
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSystemV2.CurrentLevel = playerData.currentLevelData;
        showLevelCaseV2.ShowLevel(levelSystemV2.CurrentLevel);
        Debug.Log("LevelSelect: " + levelSystemV2.CurrentLevel);
    }
    protected internal void SettingAnimals(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.animal[i];
        }
    }
    protected internal void CheckingAnimal(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerData.animal[i])
            {
                IOA[i].OnHandlePickUpLoad();
            }
        }
    }
    protected internal void SettingVegetals(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 5; j < 10; j++)
            {
                inventoryItemDataV2[j].itemIsCheck = playerData.vegetal[i];
            }
        }
    }
    protected internal void CheckingVegetal(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerData.vegetal[i])
            {
                IOV[i].OnHandlePickUpLoad();
            }
        }
    }
    protected internal void SetQuestSingleton(ScoreData scoreData)
    {
        questLevel._endQuest = scoreData._endQuestV2;
        questLevel.CaseValue = scoreData._caseValueV2;
    }
    protected internal void SetPlayerPositionUnLoad(int index)
    {
        playerMove.transform.position = targetPlayerPosition[index].position;
    }
    protected internal void SetDestroyObject(int _value)
    {
        Action action = _value switch
        {
            12 => () => showLevelCaseV2.DestroyingObjects(0),
            _ => () => Debug.Log("Case default!")
        };
        action();
    }
}