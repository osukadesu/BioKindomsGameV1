using UnityEngine;
public class LoadGame : MonoBehaviour
{
    [SerializeField] protected internal PlayerMove playerMove;
    [SerializeField] protected internal LevelSystem levelSystem;
    [SerializeField] protected internal ItemObject[] IOAS;
    [SerializeField] protected internal ItemObjectA2[] IOVS;
    [SerializeField] protected internal InventoryUI inventoryUIA;
    [SerializeField] protected internal InventoryUIV inventoryUIV;
    [SerializeField] protected internal InventoryItemDataV2[] inventoryItemDataV2;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    protected internal void GoNew()
    {
        SettingInventory();
        levelSystem.CurrentLevel = 1;
    }
    protected internal void GoLoad()
    {
        SettingInventory();
        PlayerData playerData = SaveAndLoadManager.LoadDataGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        CheckingAnimal(playerData);
        SettingVegetals(playerData);
        CheckingVegetal(playerData);
    }
    protected internal void SettingInventory()
    {
        InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUIA.OnUpdateInventory;
        InventorySystemV.instance2.OnInventoryChangedEventCallBack += inventoryUIV.OnUpdateInventory;
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSystem.CurrentLevel = playerData.currentLevelData;
    }
    protected internal void SettingAnimals(PlayerData playerData)
    {
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.animal[i];
        }
    }
    protected internal void CheckingAnimal(PlayerData playerData)
    {
        for (int i = 0; i < IOAS.Length; i++)
        {
            if (playerData.animal[i])
            {
                IOAS[i].OnHandlePickUpLoad();
            }
        }
    }
    protected internal void SettingVegetals(PlayerData playerData)
    {
        for (int i = 0; i < inventoryItemDataV2.Length; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.vegetal[i];
        }
    }
    protected internal void CheckingVegetal(PlayerData playerData)
    {
        for (int i = 0; i < IOVS.Length; i++)
        {
            if (playerData.vegetal[i])
            {
                IOVS[i].OnHandlePickUpLoad();
            }
        }
    }
}
/*
 [SerializeField] CraftBuilderSystem craftBuilderSystem;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] ItemObject IOA1P1, IOA1P2, IOA1P3, IOA1P4, IOA1P5;
    [SerializeField] ItemObjectA2 IOA2P1, IOA2P2, IOA2P3, IOA2P4, IOA2P5;
    [SerializeField] ItemObjectA3 IOA3P1, IOA3P2, IOA3P3, IOA3P4, IOA3P5;
    [SerializeField] ItemObjectA4 IOA4P1, IOA4P2, IOA4P3, IOA4P4, IOA4P5;
    [SerializeField] ItemObjectA5 IOA5P1, IOA5P2, IOA5P3, IOA5P4, IOA5P5;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] InventoryUIV InventoryUIV;
    [SerializeField] InventoryUIA3 inventoryUIA3;
    [SerializeField] InventoryUIA4 inventoryUIA4;
    [SerializeField] InventoryUIA5 inventoryUIA5;
    [SerializeField] float timerLoad;
    void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        craftBuilderSystem = FindObjectOfType<CraftBuilderSystem>();
        timerLoad = 1.0f;
    }
    void Update()
    {
        timerLoad -= .5f * Time.deltaTime;
    }
    public void GoNewGame()
    {
        if (timerLoad <= .0f)
        {
            InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUI.OnUpdateInventory;
            InventorySystemV.instance2.OnInventoryChangedEventCallBack += InventoryUIV.OnUpdateInventory;
            InventorySystemA3.instance3.OnInventoryChangedEventCallBack += inventoryUIA3.OnUpdateInventory;
            InventorySystemA4.instance4.OnInventoryChangedEventCallBack += inventoryUIA4.OnUpdateInventory;
            InventorySystemA5.instance5.OnInventoryChangedEventCallBack += inventoryUIA5.OnUpdateInventory;
            timerLoad = 0;
        }
    }
    public void GoLoadGame()
    {
        if (timerLoad <= .0f)
        {
            InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUI.OnUpdateInventory;
            InventorySystemV.instance2.OnInventoryChangedEventCallBack += InventoryUIV.OnUpdateInventory;
            InventorySystemA3.instance3.OnInventoryChangedEventCallBack += inventoryUIA3.OnUpdateInventory;
            InventorySystemA4.instance4.OnInventoryChangedEventCallBack += inventoryUIA4.OnUpdateInventory;
            InventorySystemA5.instance5.OnInventoryChangedEventCallBack += inventoryUIA5.OnUpdateInventory;
            PlayerData playerData = SaveAndLoadManager.LoadDataGame();
            SettingPlayerPosition(playerData);
            SettingAnimals(playerData);
            CheckingAnimals(playerData);
            timerLoad = 0;
        }
    }
    public void SettingPlayerPosition(PlayerData playerData)
    {
        playerMove.transform.position = new Vector3(
            playerData.position[0],
            playerData.position[1],
            playerData.position[2]);
    }
    void SettingAnimals(PlayerData playerData)
    {
        SettingAnimal1(playerData);
        SettingAnimal2(playerData);
        SettingAnimal3(playerData);
        SettingAnimal4(playerData);
        SettingAnimal5(playerData);
    }
    void SettingAnimal1(PlayerData playerData)
    {
        craftBuilderSystem._InventoryItemDatas[0].itemIsCheck = playerData.animal11;
        craftBuilderSystem._InventoryItemDatas[1].itemIsCheck = playerData.animal12;
        craftBuilderSystem._InventoryItemDatas[2].itemIsCheck = playerData.animal13;
        craftBuilderSystem._InventoryItemDatas[3].itemIsCheck = playerData.animal14;
        craftBuilderSystem._InventoryItemDatas[4].itemIsCheck = playerData.animal15;
        craftBuilderSystem.IsCreated[0] = playerData.isCreatedA1;
    }
    void SettingAnimal2(PlayerData playerData)
    {
        craftBuilderSystem._InventoryItemDatas[5].itemIsCheck = playerData.animal21;
        craftBuilderSystem._InventoryItemDatas[6].itemIsCheck = playerData.animal22;
        craftBuilderSystem._InventoryItemDatas[7].itemIsCheck = playerData.animal23;
        craftBuilderSystem._InventoryItemDatas[8].itemIsCheck = playerData.animal24;
        craftBuilderSystem._InventoryItemDatas[9].itemIsCheck = playerData.animal25;
        craftBuilderSystem.IsCreated[1] = playerData.isCreatedA2;
    }
    void SettingAnimal3(PlayerData playerData)
    {
        craftBuilderSystem._InventoryItemDatas[10].itemIsCheck = playerData.animal31;
        craftBuilderSystem._InventoryItemDatas[11].itemIsCheck = playerData.animal32;
        craftBuilderSystem._InventoryItemDatas[12].itemIsCheck = playerData.animal33;
        craftBuilderSystem._InventoryItemDatas[13].itemIsCheck = playerData.animal34;
        craftBuilderSystem._InventoryItemDatas[14].itemIsCheck = playerData.animal35;
        craftBuilderSystem.IsCreated[2] = playerData.isCreatedA3;
    }
    void SettingAnimal4(PlayerData playerData)
    {
        craftBuilderSystem._InventoryItemDatas[15].itemIsCheck = playerData.animal31;
        craftBuilderSystem._InventoryItemDatas[16].itemIsCheck = playerData.animal32;
        craftBuilderSystem._InventoryItemDatas[17].itemIsCheck = playerData.animal33;
        craftBuilderSystem._InventoryItemDatas[18].itemIsCheck = playerData.animal34;
        craftBuilderSystem._InventoryItemDatas[19].itemIsCheck = playerData.animal35;
        craftBuilderSystem.IsCreated[3] = playerData.isCreatedA4;
    }
    void SettingAnimal5(PlayerData playerData)
    {
        craftBuilderSystem._InventoryItemDatas[20].itemIsCheck = playerData.animal41;
        craftBuilderSystem._InventoryItemDatas[21].itemIsCheck = playerData.animal42;
        craftBuilderSystem._InventoryItemDatas[22].itemIsCheck = playerData.animal43;
        craftBuilderSystem._InventoryItemDatas[23].itemIsCheck = playerData.animal44;
        craftBuilderSystem._InventoryItemDatas[24].itemIsCheck = playerData.animal45;
        craftBuilderSystem.IsCreated[4] = playerData.isCreatedA5;
    }
    void CheckingAnimals(PlayerData playerData)
    {
        CheckingDataAnimal1(playerData);
        CheckingDataAnimal2(playerData);
        CheckingDataAnimal3(playerData);
        CheckingDataAnimal4(playerData);
        CheckingDataAnimal5(playerData);
    }
    void CheckingDataAnimal1(PlayerData playerData)
    {
        if (playerData.animal11)
        {
            IOA1P1.OnHandlePickUpLoad();
        }
        if (playerData.animal12)
        {
            IOA1P2.OnHandlePickUpLoad();
        }
        if (playerData.animal13)
        {
            IOA1P3.OnHandlePickUpLoad();
        }
        if (playerData.animal14)
        {
            IOA1P4.OnHandlePickUpLoad();
        }
        if (playerData.animal15)
        {
            IOA1P5.OnHandlePickUpLoad();
        }
        if (playerData.isCreatedA1)
        {
            craftBuilderSystem.ButtonBuildItem1();
        }
    }
    void CheckingDataAnimal2(PlayerData playerData)
    {
        if (playerData.animal21)
        {
            IOA2P1.OnHandlePickUpLoad();
        }
        if (playerData.animal22)
        {
            IOA2P2.OnHandlePickUpLoad();
        }
        if (playerData.animal23)
        {
            IOA2P3.OnHandlePickUpLoad();
        }
        if (playerData.animal24)
        {
            IOA2P4.OnHandlePickUpLoad();
        }
        if (playerData.animal25)
        {
            IOA2P5.OnHandlePickUpLoad();
        }
        if (playerData.isCreatedA2)
        {
            craftBuilderSystem.ButtonBuildItem2();
        }
    }
    void CheckingDataAnimal3(PlayerData playerData)
    {
        if (playerData.animal31)
        {
            IOA3P1.OnHandlePickUpLoad();
        }
        if (playerData.animal32)
        {
            IOA3P2.OnHandlePickUpLoad();
        }
        if (playerData.animal33)
        {
            IOA3P3.OnHandlePickUpLoad();
        }
        if (playerData.animal34)
        {
            IOA3P4.OnHandlePickUpLoad();
        }
        if (playerData.animal35)
        {
            IOA3P5.OnHandlePickUpLoad();
        }
        if (playerData.isCreatedA3)
        {
            craftBuilderSystem.ButtonBuildItem3();
        }
    }
    void CheckingDataAnimal4(PlayerData playerData)
    {
        if (playerData.animal41)
        {
            IOA4P1.OnHandlePickUpLoad();
        }
        if (playerData.animal42)
        {
            IOA4P2.OnHandlePickUpLoad();
        }
        if (playerData.animal43)
        {
            IOA4P3.OnHandlePickUpLoad();
        }
        if (playerData.animal44)
        {
            IOA4P4.OnHandlePickUpLoad();
        }
        if (playerData.animal45)
        {
            IOA4P5.OnHandlePickUpLoad();
        }
        if (playerData.isCreatedA4)
        {
            craftBuilderSystem.ButtonBuildItem4();
        }
    }
    void CheckingDataAnimal5(PlayerData playerData)
    {
        if (playerData.animal51)
        {
            IOA5P1.OnHandlePickUpLoad();
        }
        if (playerData.animal52)
        {
            IOA5P2.OnHandlePickUpLoad();
        }
        if (playerData.animal53)
        {
            IOA5P3.OnHandlePickUpLoad();
        }
        if (playerData.animal54)
        {
            IOA5P4.OnHandlePickUpLoad();
        }
        if (playerData.animal55)
        {
            IOA5P5.OnHandlePickUpLoad();
        }
        if (playerData.isCreatedA5)
        {
            craftBuilderSystem.ButtonBuildItem5();
        }
    }
*/