[System.Serializable]
public class PlayerData
{
    public bool[] animal = new bool[25];
    public bool[] vegetal = new bool[25];
    public bool[] fungi = new bool[25];
    public bool[] protista = new bool[25];
    public bool[] monera = new bool[25];
    public bool[] isCreatedA = new bool[5];
    public bool[] isCreatedV = new bool[5];
    public bool[] isCreatedF = new bool[5];
    public bool[] isCreatedP = new bool[5];
    public bool[] isCreatedM = new bool[5];
    public int currentLevelData, textCountData;
    public float lifeValue;
    public PlayerData(LevelSystem levelSystem)
    {
        MappingLevels(levelSystem);
    }
    public PlayerData(LevelSystem levelSystem, CraftBuilderSystem craftBuilderSystem, TextCount textCount, DeadPlayer deadPlayer)
    {
        MappingLevels(levelSystem);
        MappingAnimals(craftBuilderSystem);
        MappingTextCount(textCount);
        MappingLife(deadPlayer);
    }
    void MappingLife(DeadPlayer deadPlayer)
    {
        lifeValue = deadPlayer.lifeControllerPlayer._CurrentLife;
    }
    void MappingTextCount(TextCount textCount)
    {
        textCountData = textCount.numItem;
    }
    void MappingLevels(LevelSystem levelSystem)
    {
        currentLevelData = levelSystem.CurrentLevel;
    }
    void MappingAnimals(CraftBuilderSystem craftBuilderSystem)
    {
        for (int i = 0; i < animal.Length; i++)
        {
            animal[i] = craftBuilderSystem._InventoryItemDatas[i].itemIsCheck;
        }
        for (int j = 0; j < craftBuilderSystem.IsCreated.Length; j++)
        {
            isCreatedA[j] = craftBuilderSystem.IsCreated[j];
        }
    }
    void MappingVegetals(CraftBuilderSystem craftBuilderSystem)
    {
        for (int i = 0; i < vegetal.Length; i++)
        {
            int iterateIndex = i;
            vegetal[i] = craftBuilderSystem._InventoryItemDatas[iterateIndex].itemIsCheck;
        }
        for (int j = 0; j < craftBuilderSystem.IsCreated.Length; j++)
        {
            int iterateIndex = j;
            isCreatedV[j] = craftBuilderSystem.IsCreated[iterateIndex];
        }
    }
    void MappingFungis(CraftBuilderSystem craftBuilderSystem)
    {
        for (int i = 0; i < fungi.Length; i++)
        {
            int iterateIndex = i;
            fungi[i] = craftBuilderSystem._InventoryItemDatas[iterateIndex].itemIsCheck;
        }
        for (int j = 0; j < craftBuilderSystem.IsCreated.Length; j++)
        {
            int iterateIndex = j;
            isCreatedF[j] = craftBuilderSystem.IsCreated[iterateIndex];
        }
    }
    void MappingProtista(CraftBuilderSystem craftBuilderSystem)
    {
        for (int i = 0; i < protista.Length; i++)
        {
            int iterateIndex = i;
            protista[i] = craftBuilderSystem._InventoryItemDatas[iterateIndex].itemIsCheck;
        }
        for (int j = 0; j < craftBuilderSystem.IsCreated.Length; j++)
        {
            int iterateIndex = j;
            isCreatedP[j] = craftBuilderSystem.IsCreated[iterateIndex];
        }
    }
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
}