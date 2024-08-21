using System.Collections;
using UnityEngine;
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
    public void SaveLevel()
    {
        StartCoroutine(IESaveLevel());
    }
    IEnumerator IESaveLevel()
    {
        yield return new WaitForSeconds(.5f);
        SaveGame();
    }
    protected internal void SaveGame()
    {
        SaveAndLoadManager.SaveGame(levelSystemV2, inventoryItemDataV2);
        SaveAndLoadManager.SaveLevel(levelSystemV2);
        textGralController.StartingAT2("Partida Guardada!");
    }
}