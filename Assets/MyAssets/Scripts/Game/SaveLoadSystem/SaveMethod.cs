using UnityEngine;
using UnityEngine.UI;
public class SaveMethod : MonoBehaviour
{
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] TextGralController textGralController;
    void Awake()
    {
        textGralController = FindObjectOfType<TextGralController>();
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
    }
    protected internal void SaveGame()
    {
        SaveAndLoadManager.SaveGame(levelSystemV2, inventoryItemDataV2);
        SaveAndLoadManager.SaveLevel(levelSystemV2);
        textGralController.StartingAT2("Partida Guardada!");
    }
}