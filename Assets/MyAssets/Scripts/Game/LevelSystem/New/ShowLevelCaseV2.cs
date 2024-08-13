using System;
using System.Collections;
using UnityEngine;
public class ShowLevelCaseV2 : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] MouseController mouseController;
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] PlayerEstanteCol playerEstanteCol;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] GameObject _NextLevel, levelFight, platformV2;
    [SerializeField] Animator nextLevelAnim;
    [SerializeField] protected internal GameObject[] enemy, money, questKing, exitQuest, changeLevel;
    [SerializeField] protected internal GameObject pedestal;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
    }
    void Update()
    {
        ItemCondition();
    }
    protected internal void ShowLevel(int level)
    {
        Debug.Log("Current Level: " + level);
        switch (level)
        {
            case 1:
                platformV2.SetActive(true);
                SwitchQuestExitKing(0);
                StartCoroutine(LevelTutorialCoroutine());
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 2:
                LevelFight();
                SwitchQuestExitKing(0);
                StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, false, 1, true);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 3:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 4:
                LevelFight();
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 5:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 6:
                LevelFight();
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 7:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 8:
                LevelFight();
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 9:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 10:
                LevelFight();
                SwitchQuestExitKing(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 11:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(1);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 12:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                SwitchQuestExitKing(2);
                DestroyingObjects(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                SaveLevel();
                break;
            case 13:
                LevelFight();
                SwitchQuestExitKing(2);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
        }
    }
    public void DestroyingObjects(int _index)
    {
        Destroy(questKing[_index], .2f);
        Destroy(exitQuest[_index], .2f);
        Destroy(changeLevel[_index], .2f);
    }
    void SwitchQuestExitKing(int _value)
    {
        switch (_value)
        {
            case 0:
                for (int i = 0; i < 5; i++)
                {
                    QuestExitKing(i, false);
                }
                break;
            case 1:
                QuestExitKing(0, true);
                QuestExitKing(1, false);
                QuestExitKing(2, false);
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 2:
                QuestExitKing(1, false);
                QuestExitKing(2, false);
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 3:
                QuestExitKing(1, true);
                QuestExitKing(2, false);
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 4:
                QuestExitKing(2, false);
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 5:
                QuestExitKing(2, true);
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 6:
                QuestExitKing(3, false);
                QuestExitKing(4, false);
                break;
            case 7:
                QuestExitKing(3, true);
                QuestExitKing(4, false);
                break;
            case 8:
                QuestExitKing(4, false);
                break;
            case 9:
                QuestExitKing(4, true);
                break;
        }
    }
    void QuestExitKing(int _index, bool _bool)
    {
        questKing[_index].SetActive(_bool);
        exitQuest[_index].SetActive(questLevel._endQuest);
    }
    IEnumerator LevelTutorialCoroutine()
    {
        yield return new WaitForSeconds(1f);
        mouseController.MouseUnLock();
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
    protected internal void LevelFight()
    {
        StartCoroutine(IECanshot(true));
        levelFight.SetActive(true);
        platformV2.SetActive(false);
        NextLevelMethod(false);
        enemy[playerEstanteCol.setId].SetActive(true);
        money[playerEstanteCol.setId].SetActive(false);
        pedestal.SetActive(false);
    }

    IEnumerator IECanshot(bool _canShoot)
    {
        yield return new WaitForSeconds(1f);
        shootLogic.canShoot = _canShoot;
    }
    public void SaveLevel()
    {
        StartCoroutine(IESaveLevel());
    }
    IEnumerator IESaveLevel()
    {
        yield return new WaitForSeconds(.5f);
        saveMethod.SaveGame();
    }
    void ItemCondition()
    {
        NextLevelMethod(loadLevelSystem.inventoryItemDataV2[playerEstanteCol.setId].itemIsCheck);
    }
    void NextLevelMethod(bool _value)
    {
        _NextLevel.SetActive(_value);
        nextLevelAnim.SetBool("nextLevelShow", _value);
    }
}