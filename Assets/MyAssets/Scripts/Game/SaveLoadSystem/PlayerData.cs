[System.Serializable]
public class PlayerData
{
    public bool[] animal = new bool[5];
    public bool[] vegetal = new bool[5];
    public int currentLevelData;
    public PlayerData(LevelSystemV2 levelSystemV2, LoadLevelSystem loadLevelSystem)
    {
        MappingLevels(levelSystemV2);
        MappingAnimals(loadLevelSystem);
        MappingVegetals(loadLevelSystem);
    }
    public PlayerData(LevelSystemV2 levelSystemV2)
    {
        MappingLevels(levelSystemV2);
    }
    void MappingLevels(LevelSystemV2 levelSystemV2)
    {
        currentLevelData = levelSystemV2.CurrentLevel;
    }
    void MappingAnimals(LoadLevelSystem loadLevelSystem)
    {
        for (int i = 0; i < animal.Length; i++)
        {
            animal[i] = loadLevelSystem.inventoryItemDataV2[i].itemIsCheck;
        }
    }
    void MappingVegetals(LoadLevelSystem loadLevelSystem)
    {
        for (int i = 0; i < vegetal.Length; i++)
        {
            vegetal[i] = loadLevelSystem.iIDV[i].itemIsCheck;
        }
    }
}