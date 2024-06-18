using UnityEngine;
public class LoadLevelSystem : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] protected internal ItemObject[] IOAS;
    [SerializeField] protected internal InventoryUI inventoryUIA;
    [SerializeField]  protected internal InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystemV2 levelSystem;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] Transform[] targetPlayerPosition;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystemV2>();
        inventoryUIA = FindObjectOfType<InventoryUI>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    protected internal void GoNewGameAndLevel()
    {
        SetInventoryUI();
        levelSystem.CurrentLevel = 1;
        showLevelCaseV2.ShowLevel(levelSystem.CurrentLevel);
    }
    protected internal void GoLoadGame()
    {
        SetInventoryUI();
        PlayerData playerData = SaveAndLoadManager.LoadDataGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        CheckingAnimal(playerData);
    }
    protected internal void GoLoadLevel()
    {
        SetInventoryUI();
        PlayerData playerData = SaveAndLoadManager.LoadLevelGame();
        SettingLevels(playerData);
        SettingAnimals(playerData);
        CheckingAnimal(playerData);
    }
    protected internal void SetInventoryUI()
    {
        InventorySystem.instance.OnInventoryChangedEventCallBack += inventoryUIA.OnUpdateInventory;
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSystem.CurrentLevel = playerData.currentLevelData;
        showLevelCaseV2.ShowLevel(levelSystem.CurrentLevel);
        Debug.Log("LevelSelect: " + levelSystem.CurrentLevel);
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
    protected internal void SetPlayerPositionUnLoad(int index)
    {
        playerMove.transform.position = targetPlayerPosition[index].position;
    }
}