using UnityEngine;
using UnityEngine.UI;
public class SaveMethod : MonoBehaviour
{
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] TextGralController textGralController;
    void Awake()
    {
        textGralController = FindObjectOfType<TextGralController>();
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
    }
    protected internal void SaveGame()
    {
        SaveAndLoadManager.SaveGame(levelSystemV2, loadLevelSystem);
        SaveAndLoadManager.SaveLevel(levelSystemV2);
        textGralController.StartingAT2("Partida Guardada!");
    }
}