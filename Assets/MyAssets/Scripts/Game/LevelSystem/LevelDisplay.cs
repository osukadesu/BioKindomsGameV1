using System;
using UnityEngine;
public class LevelDisplay : MonoBehaviour
{
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] PlayerEstanteCol playerEstanteCol;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] QuestGameObjects questGameObjects;
    [SerializeField] Notification notification;
    [SerializeField] PlayerPosition playerPosition;
    [SerializeField] EnemyStats enemyStats;
    [SerializeField] GameObject levelFight, platformV2;
    [SerializeField] EscapeLogicGame escapeLogicGame;
    [SerializeField] protected internal Animator nextLevelAnim, pedestalAnim;
    public GameObject[] enemy, money;
    [SerializeField] BoxCollider boxCollider;
    void Awake()
    {
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
        playerEstanteCol = FindObjectOfType<PlayerEstanteCol>();
        shootLogic = FindObjectOfType<ShootLogic>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
        saveMethod = FindObjectOfType<SaveMethod>();
        questGameObjects = FindObjectOfType<QuestGameObjects>();
        notification = FindObjectOfType<Notification>();
        playerPosition = FindObjectOfType<PlayerPosition>();
        enemyStats = FindObjectOfType<EnemyStats>();
        escapeLogicGame = FindObjectOfType<EscapeLogicGame>();
    }
    void Start()
    {
        ElementsHide();
        LevelPlatform();
    }
    void Update()
    {
        if (nextLevelAnim.isActiveAndEnabled)
        {
            ItemCondition();
        }
    }
    void ElementsHide()
    {
        for (int i = 0; i < money.Length; i++) { money[i].SetActive(false); }
        for (int i = 0; i < enemy.Length; i++) { enemy[i].SetActive(false); }
    }
    public void ShowLevel(int level)
    {
        Action action = level switch
        {
            1 or 3 or 5 or 7 or 9 or 11 or 12 or 14 or 16 or 18 or 20 or 22 or 23 or 25 or 27 or 29 or 31 or 33 or 34 or 36 or 38
            or 40 or 42 or 44 or 45 or 47 or 49 or 51 or 53 or 55 or 56 => () => SetLevelType(IsPlatform()),
            2 or 4 or 6 or 8 or 10 or 13 or 15 or 17 or 19 or 21 or 24 or 26 or 28 or 30 or 32 or 35 or 37 or 39 or 41 or 43 or 46
            or 48 or 50 or 52 or 54 => () => SetLevelType(IsFight()),
            _ => () => Debug.Log("Current Level in default"),
        };
        action();
        Debug.Log("Current Level: " + level);
        alertModalManager.ShowTutorialAlerts(level);
        playerPosition.SetPlayerPositionWithConditions(level);
        saveMethod.SaveLevel(level);
        GeneralSingleton.generalSingleton.SetIscloseInfo(level);
        questGameObjects.DestroyObjects(level);
        questGameObjects.QuestExitKingInLevel(level);
        loadLevelSystem.LoadSingletonQuest(level);
        notification.SetNotificationsLevel(level);
        enemyStats.SetKingdomStatsInLevel(level);
        escapeLogicGame.IsCanEscape(level);
    }
    bool IsPlatform() { return true; }
    bool IsFight() { return false; }
    void SetLevelType(bool _isPlataform)
    {
        Action action = _isPlataform switch
        {
            true => () => LevelPlatform(),
            false => () => LevelFight(),
        };
        action();
    }
    void LevelPlatform()
    {
        platformV2.SetActive(true);
        levelFight.SetActive(false);
    }
    void LevelFight()
    {
        shootLogic.SetCanShoot();
        levelFight.SetActive(true);
        platformV2.SetActive(false);
        NextLevelMethod(false);
        enemy[playerEstanteCol.setId].SetActive(true);
        money[playerEstanteCol.setId].SetActive(false);
        pedestalAnim.SetBool("pedestalShow", false);
    }
    void ItemCondition() => NextLevelMethod(loadLevelSystem.inventoryItemDataV2[playerEstanteCol.setId].itemIsCheck);
    void NextLevelMethod(bool _value)
    {
        boxCollider.enabled = _value;
        nextLevelAnim.SetBool("nextLevelShow", _value);
    }
}