using System;
using System.Collections;
using UnityEngine;
public class SaveMethod : MonoBehaviour
{
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] TextGralController textGralController;
    void Awake()
    {
        textGralController = FindObjectOfType<TextGralController>();
        levelSystemV2 = FindObjectOfType<LevelSystem>();
    }
    public void SaveLevel(int _level)
    {
        Action action = _level switch
        {
            3 or 5 or 7 or 9 or 11 or 12 or 14 or 16 or 18 or 20 or 22 or 23
            => () => { StartCoroutine(IESaveLevel()); }
            ,
            _ => () => Debug.Log("Default case!"),
        };
        action();
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