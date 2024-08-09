[System.Serializable]
public class PlayerData
{
    public bool[] animal = new bool[5];
    public bool[] vegetal = new bool[5];
    public bool _endQuestV2;
    public int currentLevelData, _caseValueV2;
    public PlayerData(LevelSystemV2 levelSystemV2, InventoryItemDataV2[] inventoryItemDataV2)
    {
        MappingLevels(levelSystemV2);
        MappingAnimals(inventoryItemDataV2);
        MappingVegetals(inventoryItemDataV2);
    }
    public PlayerData(LevelSystemV2 levelSystemV2)
    {
        MappingLevels(levelSystemV2);
    }
    void MappingLevels(LevelSystemV2 levelSystemV2)
    {
        currentLevelData = levelSystemV2.CurrentLevel;
    }
    void MappingAnimals(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < 5; i++)
        {
            animal[i] = inventoryItemDataV2[i].itemIsCheck;
        }
    }
    void MappingVegetals(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < 5; i++)
        {
            for (int j = 5; j < 10; j++)
            {
                vegetal[i] = inventoryItemDataV2[j].itemIsCheck;
            }
        }
    }
    public PlayerData(QuestLevel questLevel)
    {
        MappingQuestSingleton(questLevel);
    }
    void MappingQuestSingleton(QuestLevel questLevel)
    {
        _endQuestV2 = questLevel._endQuest;
        _caseValueV2 = questLevel.CaseValue;
    }
}