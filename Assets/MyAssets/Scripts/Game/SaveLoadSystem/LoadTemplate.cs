using UnityEngine;
public abstract class LoadTemplate : MonoBehaviour
{
    [SerializeField] protected internal TextCount textCount;
    [SerializeField] protected internal PlayerMove playerMove;
    [SerializeField] protected internal LevelSystem levelSystem;
    [SerializeField] protected internal LevelSelect levelSelect;
    [SerializeField] protected internal ItemObject[] IOA1;
    [SerializeField] protected internal ItemObjectA2[] IOA2;
    [SerializeField] protected internal ItemObjectA3[] IOA3;
    [SerializeField] protected internal ItemObjectA4[] IOA4;
    [SerializeField] protected internal ItemObjectA5[] IOA5;
    [SerializeField] protected internal InventoryUI inventoryUI;
    [SerializeField] protected internal InventoryUIA2 inventoryUIA2;
    [SerializeField] protected internal InventoryUIA3 inventoryUIA3;
    [SerializeField] protected internal InventoryUIA4 inventoryUIA4;
    [SerializeField] protected internal InventoryUIA5 inventoryUIA5;
    [SerializeField] protected internal CraftBuilderSystem craftBuilderSystem;
    void Awake()
    {
        textCount = FindObjectOfType<TextCount>();
        levelSelect = FindObjectOfType<LevelSelect>();
        levelSystem = FindObjectOfType<LevelSystem>();
        craftBuilderSystem = FindObjectOfType<CraftBuilderSystem>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    protected internal abstract void GoNew();
    protected internal abstract void GoLoad();
    protected internal void SettingGoNew(bool setInventory)
    {
        if (setInventory)
        {
            SettingInventory();
            levelSelect.currentLevel = 1;
        }
        else
        {
            levelSelect.currentLevel = 1;
        }
    }
    protected internal void SettingInventory()
    {
        InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUI.OnUpdateInventory;
        InventorySystemA2.instance2.OnInventoryChangedEventCallBack += inventoryUIA2.OnUpdateInventory;
        InventorySystemA3.instance3.OnInventoryChangedEventCallBack += inventoryUIA3.OnUpdateInventory;
        InventorySystemA4.instance4.OnInventoryChangedEventCallBack += inventoryUIA4.OnUpdateInventory;
        InventorySystemA5.instance5.OnInventoryChangedEventCallBack += inventoryUIA5.OnUpdateInventory;
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
    }
    protected internal void SettingAnimals(PlayerData playerData)
    {
        for (int i = 0; i < 25; i++)
        {
            craftBuilderSystem._InventoryItemDatas[i].itemIsCheck = playerData.animal[i];
        }
        for (int j = 0; j < playerData.isCreatedA.Length; j++)
        {
            craftBuilderSystem.IsCreated[j] = playerData.isCreatedA[j];
        }
    }
    protected internal void SettingTextCount(PlayerData playerData)
    {
        textCount.numItem = playerData.textCountData;
    }
    protected internal void CheckingAnimals(PlayerData playerData)
    {
        CheckingAnimal1(playerData);
    }
    protected internal void CheckingAnimal1(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            if (playerData.animal[i])
            {
                IOA1[i].OnHandlePickUpLoad();
            }
        }
        if (playerData.isCreatedA[0])
        {
            craftBuilderSystem.ButtonBuildItem(0);
        }
    }
}