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
    [SerializeField] protected internal Animator nextLevelAnim, pedestalAnim;
    [SerializeField] protected internal GameObject[] enemy, money;
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
    }
    void Start()
    {
        ElementsHide();
        LevelPlatform();
    }
    void Update()
    {
        ItemCondition();
    }
    void ElementsHide()
    {
        for (int i = 0; i < money.Length; i++) { money[i].SetActive(false); }
        for (int i = 0; i < enemy.Length; i++) { enemy[i].SetActive(false); }
    }
    protected internal void ShowLevel(int level)
    {
        Action action = level switch
        {
            1 or 3 or 5 or 7 or 9 or 11 or 12 or 14 or 16 or 18 or 20 or 22 or 23
            => () => SetLevelType(true),
            2 or 4 or 6 or 8 or 10 or 13 or 15 or 17 or 19 or 21 or 24
            => () => SetLevelType(false),
            _ => () => Debug.Log("Current Level in default"),
        };
        action();
        Debug.Log("Current Level: " + level);
        alertModalManager.ShowTutorialAlerts(level);
        playerPosition.SetPlayerPositionWithConditionsV2(level);
        saveMethod.SaveLevel(level);
        GeneralSingleton.generalSingleton.SetIscloseInfo(level);
        questGameObjects.DestroyObjects(level);
        questGameObjects.QuestExitKingInLevel(level);
        loadLevelSystem.LoadSingletonQuest(level);
        notification.SetNotificationsLevel(level);
        enemyStats.SetKingdomStatsInLevel(level);
    }
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
    void ItemCondition()
    {
        NextLevelMethod(loadLevelSystem.inventoryItemDataV2[playerEstanteCol.setId].itemIsCheck);
    }
    void NextLevelMethod(bool _value)
    {
        boxCollider.enabled = _value;
        nextLevelAnim.SetBool("nextLevelShow", _value);
    }
}