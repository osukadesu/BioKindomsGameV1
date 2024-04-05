using UnityEngine;
public abstract class LoadTemplate : MonoBehaviour
{
    [SerializeField] protected internal LevelSelect levelSelect;
    [SerializeField] protected internal ItemObject[] IOA1;
    [SerializeField] protected internal ItemObjectA2[] IOA2;
    [SerializeField] protected internal ItemObjectA3[] IOA3;
    [SerializeField] protected internal ItemObjectA4[] IOA4;
    [SerializeField] protected internal ItemObjectA5[] IOA5;
    [SerializeField] protected internal InventoryUI inventoryUI;
    [SerializeField] protected internal InventoryUIV InventoryUIV;
    [SerializeField] protected internal InventoryUIA3 inventoryUIA3;
    [SerializeField] protected internal InventoryUIA4 inventoryUIA4;
    [SerializeField] protected internal InventoryUIA5 inventoryUIA5;
    [SerializeField] protected internal InventoryItemDataV2[] inventoryItemDataV2;
    void Awake()
    {
        levelSelect = FindObjectOfType<LevelSelect>();
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
    }
    protected internal void SettingLevels(PlayerData playerData)
    {
        levelSelect.currentLevel = playerData.currentLevelData;
    }
    protected internal void SettingAnimals(PlayerData playerData)
    {
        for (int i = 0; i < 5; i++)
        {
            inventoryItemDataV2[i].itemIsCheck = playerData.animal[i];
        }
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
    }
}