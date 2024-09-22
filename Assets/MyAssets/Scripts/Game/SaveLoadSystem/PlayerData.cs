[System.Serializable]
public class PlayerData
{
    public bool[] kingdoms = new bool[15];
    public int currentLevelData;
    public PlayerData(LevelSystem levelSystemV2, InventoryItemDataV2[] inventoryItemDataV2)
    {
        MappingLevels(levelSystemV2);
        MappingKingdoms(inventoryItemDataV2);
    }
    public PlayerData(LevelSystem levelSystemV2) => MappingLevels(levelSystemV2);
    void MappingLevels(LevelSystem levelSystemV2) => currentLevelData = levelSystemV2.CurrentLevel;
    void MappingKingdoms(InventoryItemDataV2[] inventoryItemDataV2)
    {
        for (int i = 0; i < kingdoms.Length; i++)
        {
            kingdoms[i] = inventoryItemDataV2[i].itemIsCheck;
        }
    }
}
