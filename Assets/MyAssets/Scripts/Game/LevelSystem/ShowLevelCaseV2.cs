using System;
using System.Collections;
using UnityEngine;
public class ShowLevelCaseV2 : MonoBehaviour
{
    [SerializeField] QuestGameObjects questGameObjects;
    [SerializeField] EnemyStats enemyStats;
    [SerializeField] PlayerPosition playerPosition;
    [SerializeField] Notification notification;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] PlayerEstanteCol playerEstanteCol;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] GameObject levelFight, platformV2;
    [SerializeField] protected internal Animator nextLevelAnim, pedestalAnim;
    [SerializeField] protected internal GameObject[] enemy, money;
    [SerializeField] BoxCollider boxCollider;
    void Awake()
    {
        questGameObjects = FindObjectOfType<QuestGameObjects>();
        enemyStats = FindObjectOfType<EnemyStats>();
        playerPosition = FindObjectOfType<PlayerPosition>();
        notification = FindObjectOfType<Notification>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
        playerEstanteCol = FindObjectOfType<PlayerEstanteCol>();
        shootLogic = FindObjectOfType<ShootLogic>();
        saveMethod = FindObjectOfType<SaveMethod>();
    }
    void Update()
    {
        ItemCondition();
    }
    protected internal void ShowLevel(int level)
    {
        Action action = level switch
        {
            1 => () =>
            {
                IsPlataformOrFight(true, false, 0, 0, null, null);
                StartCoroutine(LevelTutorialCoroutine());
            }
            ,
            2 => () =>
           {
               IsPlataformOrFight(false, null, 0, 0, 0, 0);
               StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, false, 1, true);
           }
            ,
            3 => () =>
           {
               if (!GeneralSingleton.generalSingleton.wasFirtsTime)
               {
                   notification.AddNotification("Haz desbloqueado tu perfil presiona este botón para ver!", true);
               }
               IsPlataformOrFight(true, true, 0, 1, null, null);
           }
            ,
            4 => () =>
            {
                IsPlataformOrFight(false, null, 0, 0, 0, 1);
            }
            ,
            5 => () =>
            {
                IsPlataformOrFight(true, true, 0, 1, null, null);
            }
            ,
            6 => () =>
            {
                IsPlataformOrFight(false, null, 0, 0, 0, 2);
            }
            ,
            7 => () =>
           {
               IsPlataformOrFight(true, true, 0, 1, null, null);
           }
            ,
            8 => () =>
            {
                IsPlataformOrFight(false, null, 0, 0, 0, 3);
            }
            ,
            9 => () =>
           {
               IsPlataformOrFight(true, true, 0, 1, null, null);
           }
            ,
            10 => () =>
            {
                IsPlataformOrFight(false, null, 0, 0, 0, 4);
            }
            ,
            11 => () =>
           {
               if (!GeneralSingleton.generalSingleton.endQuest)
               { DoubleNotifys("Felicidades haz completado el reino animal!", false, "Ahora ve al reino vegetal!", false); }
               IsPlataformOrFight(true, true, 1, GeneralSingleton.generalSingleton.endQuest ? 0 : 1, null, null);
           }
            ,
            12 => () =>
           {
               loadLevelSystem.GoLoadSingletonQuest();
               IsPlataformOrFight(true, true, 2, GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 1 : 0, null, null);
               questGameObjects.DestroyingObjects(0);
               //playerPosition.SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 1 : 0);
               GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] = false;
           }
            ,
            13 => () =>
            {
                loadLevelSystem.GoLoadSingletonQuest();
                IsPlataformOrFight(false, null, 2, 0, 1, 0);
            }
            ,
            14 => () =>
            {
                loadLevelSystem.GoLoadSingletonQuest();
                IsPlataformOrFight(true, true, 2, null, null, null);
                questGameObjects.DestroyingObjects(0);
                playerPosition.SetPlayerPositionWithConditions(0);
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] = false;
            }
            ,
            15 => () =>
            {
                loadLevelSystem.GoLoadSingletonQuest();
                IsPlataformOrFight(false, null, 2, 0, 1, 1);
            }
            ,
            16 => () =>
           {
               loadLevelSystem.GoLoadSingletonQuest();
               IsPlataformOrFight(true, true, 2, null, null, null);
               questGameObjects.DestroyingObjects(0);
               playerPosition.SetPlayerPositionWithConditions(0);
               GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] = false;
           }
            ,
            _ => () => Debug.Log("Current Level in default"),
        };
        action();
        Debug.Log("Current Level: " + level);
    }
    void DoubleNotifys(string _notify1, bool _isBtnNotify1, string _notify2, bool _isBtnNotify2)
    {
        notification.AddNotification(_notify1, _isBtnNotify1);
        notification.SetWaitForNotify(_notify2, _isBtnNotify2);
    }
    IEnumerator LevelTutorialCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GeneralSingleton.generalSingleton.MouseUnLock();
        alertModalManager.AlertInfo("¡Hola BioBot! Unos seres invasores han robado algunas reliquias de los reinos biológicos, tu misión es derrotarlos y recuperar las reliquias!");
        yield return new WaitForSeconds(1f);
        alertModalManager.AlertModalNew(true, "¡Presiona las teclas y ve a la puerta del reino animal!", 0, true, 1, false);
        yield return new WaitForSeconds(5f);
        alertModalManager.AlertModalNew(false, "", 0, false, 1, false);
    }
    void StartIELevelCase(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        StartCoroutine(IELevelCases(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2));
    }
    IEnumerator IELevelCases(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        alertModalManager.AlertModalNew(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2);
        yield return new WaitForSeconds(5f);
        alertModalManager.AlertModalNew(false, "", indexImg, false, indexImg, false);
    }
    void IsPlataformOrFight(bool _isPlataform, bool? _isSaving, int _QuestExitKingCase, int? _playerPositionTarget, int? _enemyKingdom, int? enemyIndex)
    {
        Action action = _isPlataform switch
        {
            true => () => { if (_isSaving.HasValue) { LevelPlatform(_isSaving.Value ? true : false); } }
            ,
            false => () => { if (_enemyKingdom.HasValue && enemyIndex.HasValue) { LevelFight(_enemyKingdom.Value, enemyIndex.Value); } }
            ,
        };
        action();
        questGameObjects.SwitchQuestExitKing(_QuestExitKingCase);
        if (_playerPositionTarget.HasValue) { playerPosition.SetPlayerPosition(_playerPositionTarget.Value); }
    }
    void LevelPlatform(bool _isSave)
    {
        platformV2.SetActive(true);
        levelFight.SetActive(false);
        if (_isSave) { saveMethod.SaveLevel(); }
    }
    void LevelFight(int _enemyKingdom, int enemyIndex)
    {
        shootLogic.SetCanShoot();
        levelFight.SetActive(true);
        platformV2.SetActive(false);
        NextLevelMethod(false);
        enemy[playerEstanteCol.setId].SetActive(true);
        money[playerEstanteCol.setId].SetActive(false);
        pedestalAnim.SetBool("pedestalShow", false);
        Action action = _enemyKingdom switch
        {
            0 => () => enemyStats.SetAnimalStats(enemyIndex),
            1 => () => enemyStats.SetVegetalStats(enemyIndex),
            /*
            2 => () => enemyStats.SetFungiStats(enemyIndex),
            3 => () => enemyStats.SetProtistaStats(enemyIndex),
            4 => () => enemyStats.SetMoneraStats(enemyIndex),
            */
            _ => () => Debug.Log("Default case!"),
        };
        action();
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