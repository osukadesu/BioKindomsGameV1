using UnityEngine;
using UnityEngine.UI;
public class SaveMethod : MonoBehaviour
{
    [SerializeField] InventoryItemDataV2[] inventoryItemDataV2;
    [SerializeField] LevelSystem levelSystem;
    [SerializeField] TextGralController textGralController;
    [SerializeField] TextCount textCount;
    [SerializeField] DeadPlayer deadPlayer;
    [SerializeField] Button btnSave;
    [SerializeField] bool enableBtnSave;
    public bool _EnableBtnSave { get => enableBtnSave; set => enableBtnSave = value; }
    void Awake()
    {
        btnSave.onClick.AddListener(MyButtonSave);
        textCount = FindObjectOfType<TextCount>();
        textGralController = FindObjectOfType<TextGralController>();
        levelSystem = FindObjectOfType<LevelSystem>();
        deadPlayer = FindObjectOfType<DeadPlayer>();
    }
    void Update()
    {
        ButtonMethod();
    }
    void ButtonMethod()
    {
        if (enableBtnSave)
        {
            btnSave.enabled = true;
        }
        else btnSave.enabled = false;
    }
    protected internal void MyButtonSave()
    {
        SaveAndLoadManager.SaveDataGame(levelSystem, inventoryItemDataV2);
        textGralController.StartingAT2("Partida Guardada!");
    }
    protected internal void SaveLevel()
    {
        SaveAndLoadManager.SaveLevel(levelSystem);
        SaveAndLoadManager.SaveForLevelGame(levelSystem, inventoryItemDataV2);
    }
}