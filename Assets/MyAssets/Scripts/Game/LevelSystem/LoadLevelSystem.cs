using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] TextCount textCount;
    [SerializeField] protected internal ItemObject[] IOA1;
    [SerializeField] CraftBuilderSystem craftBuilderSystem;
    [SerializeField] LevelSystem levelSystem;
    [SerializeField] InventoryUI inventoryUI;
    [SerializeField] ShowLevelCase showLevelCase;
    [SerializeField] Transform[] targetPlayerPosition;
    void Awake()
    {
        textCount = FindObjectOfType<TextCount>();
        levelSystem = FindObjectOfType<LevelSystem>();
        inventoryUI = FindObjectOfType<InventoryUI>();
        showLevelCase = FindObjectOfType<ShowLevelCase>();
        craftBuilderSystem = FindObjectOfType<CraftBuilderSystem>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }

    protected internal void GoNewGameAndLevel()
    {
        SetInventoryUI();
        levelSystem.CurrentLevel = 1;
        showLevelCase.ShowLevel(levelSystem.CurrentLevel);
    }
    protected internal void GoLoadGame()
    {
        SetInventoryUI();
        PlayerData playerData = SaveAndLoadManager.LoadDataGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        SettingTextCount(playerData);
        CheckingAnimals(playerData);
    }
    protected internal void GoLoadLevel()
    {
        SetInventoryUI();
        PlayerData playerData = SaveAndLoadManager.LoadLevelGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        SettingTextCount(playerData);
        CheckingAnimals(playerData);
    }
    protected internal void SetInventoryUI()
    {
        InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUI.OnUpdateInventory;
        /*        
        InventorySystemA2.instance2.OnInventoryChangedEventCallBack += inventoryUIA2.OnUpdateInventory;
        InventorySystemA3.instance3.OnInventoryChangedEventCallBack += inventoryUIA3.OnUpdateInventory;
        InventorySystemA4.instance4.OnInventoryChangedEventCallBack += inventoryUIA4.OnUpdateInventory;
        InventorySystemA5.instance5.OnInventoryChangedEventCallBack += inventoryUIA5.OnUpdateInventory;
        */
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSystem.CurrentLevel = playerData.currentLevelData;
        showLevelCase.ShowLevel(levelSystem.CurrentLevel);
        Debug.Log("LevelSelect: " + levelSystem.CurrentLevel);
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
        textCount.SetCount(playerData.textCountData);
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
    protected internal void SetPlayerPositionUnLoad(int index)
    {
        playerMove.transform.position = targetPlayerPosition[index].position;
    }
    /*protected internal void SwitchLoadLevel(int level)
    {
        SetInventoryUI();
        switch (level)
        {
            case 1:
                SetPlayerPosition(0);
                break;
            case 2:
                SetPlayerPosition(0);
                break;
            case 4:
                nextLevel.NextLevelCase(1);
                SetPlayerPosition(1);
                ItemObjectCase(0);
                break;
            case 6:
                nextLevel.NextLevelCase(2);
                SetPlayerPosition(2);
                ItemObjectCase(1);
                break;
            case 8:
                nextLevel.NextLevelCase(3);
                SetPlayerPosition(3);
                ItemObjectCase(2);
                break;
            case 10:
                nextLevel.NextLevelCase(4);
                SetPlayerPosition(4);
                ItemObjectCase(3);
                break;
            case 12:
                nextLevel.NextLevelCase(5);
                SetPlayerPosition(5);
                ItemObjectCase(4);
                break;
            case 13:
                CraftinCase(1);
                break;
        }
    }
    protected internal void SetPlayerPosition(int index)
    {
        playerMove.transform.position = targetPlayerPosition[index].position;
    }    protected internal void ItemObjectCase(int _index)
    {
        switch (_index)
        {
            case 0:
                LoopItemObject(0, 1);
                break;
            case 1:
                LoopItemObject(1, 2);
                break;
            case 2:
                LoopItemObject(2, 3);
                break;
            case 3:
                LoopItemObject(3, 4);
                break;
            case 4:
                LoopItemObject(4, 5);
                break;
        }
    } protected internal void LoopItemObject(int _length, int _textCount)
    {
        for (int i = 0; i < _length; i++)
        {
            IOA1[i].OnHandlePickUpLoad();
            textCount.numItem = _textCount;
            myTextCount[i].text = textCount.numItem + "/5";
        }
    }
    protected internal void CraftinCase(int _type)
    {
        switch (_type)
        {
            case 1:
                craftBuilderSystem.ButtonBuildItem(0);
                break;
            case 2:
                craftBuilderSystem.ButtonBuildItem(0);
                craftBuilderSystem.ButtonBuildItem(1);
                break;
            case 3:
                craftBuilderSystem.ButtonBuildItem(0);
                craftBuilderSystem.ButtonBuildItem(1);
                craftBuilderSystem.ButtonBuildItem(2);
                break;
            case 4:
                craftBuilderSystem.ButtonBuildItem(0);
                craftBuilderSystem.ButtonBuildItem(1);
                craftBuilderSystem.ButtonBuildItem(2);
                craftBuilderSystem.ButtonBuildItem(3);
                break;
            case 5:
                craftBuilderSystem.ButtonBuildItem(0);
                craftBuilderSystem.ButtonBuildItem(1);
                craftBuilderSystem.ButtonBuildItem(2);
                craftBuilderSystem.ButtonBuildItem(3);
                craftBuilderSystem.ButtonBuildItem(4);
                break;
        }
    }
    */
}