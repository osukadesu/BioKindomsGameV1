[System.Serializable]
public class PlayerData
{
    public bool[] kingdoms = new bool[10];
    public int currentLevelData;
    public PlayerData(LevelSystemV2 levelSystemV2, InventoryItemDataV2[] inventoryItemDataV2)
    {
        MappingLevels(levelSystemV2);
        MappingKingdoms(inventoryItemDataV2);
    }
    public PlayerData(LevelSystemV2 levelSystemV2)
    {
        MappingLevels(levelSystemV2);
    }
    void MappingLevels(LevelSystemV2 levelSystemV2)
    {
        currentLevelData = levelSystemV2.CurrentLevel;
    }
    void MappingKingdoms(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < kingdoms.Length; i++)
        {
            kingdoms[i] = inventoryItemDataV2[i].itemIsCheck;
        }
    }
}