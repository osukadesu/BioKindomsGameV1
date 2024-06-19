using UnityEngine;
public class SaveMethod : MonoBehaviour
{
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystemV2 levelSystem;
    [SerializeField] TextGralController textGralController;
    void Awake()
    {
        textGralController = FindObjectOfType<TextGralController>();
        levelSystem = FindObjectOfType<LevelSystemV2>();
    }
    protected internal void SaveGame()
    {
        SaveAndLoadManager.SaveGame(levelSystem, inventoryItemDataV2);
        SaveAndLoadManager.SaveLevel(levelSystem);
        textGralController.StartingAT2("Partida Guardada!");
    }
}