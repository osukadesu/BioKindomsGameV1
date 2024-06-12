[System.Serializable]
public class PlayerData
{
    public bool[] animal = new bool[5];
    public bool[] vegetal = new bool[5];
    public int currentLevelData;
    public PlayerData(LevelSystemV2 levelSystem, InventoryItemDataV2[] inventoryItemDataV2)
    {
        MappingLevels(levelSystem);
        MappingAnimals(inventoryItemDataV2);
        MappingVegetals(inventoryItemDataV2);
    }
    public PlayerData(LevelSystemV2 levelSystem)
    {
        MappingLevels(levelSystem);
    }
    void MappingLevels(LevelSystemV2 levelSystem)
    {
        currentLevelData = levelSystem.CurrentLevel;
    }
    void MappingAnimals(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < animal.Length; i++)
        {
            animal[i] = inventoryItemDataV2[i].itemIsCheck;
        }
    }
    void MappingVegetals(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < vegetal.Length; i++)
        {
            vegetal[i] = inventoryItemDataV2[i].itemIsCheck;
        }
    }
    /*
    void MappingMonera(CraftBuilderSystem craftBuilderSystem)
    {
        for (int i = 0; i < monera.Length; i++)
        {
            int iterateIndex = i;
            monera[i] = craftBuilderSystem._InventoryItemDatas[iterateIndex].itemIsCheck;
        }
        for (int j = 0; j < craftBuilderSystem.IsCreated.Length; j++)
        {
            int iterateIndex = j;
            isCreatedM[j] = craftBuilderSystem.IsCreated[iterateIndex];
        }
    }
    */
}