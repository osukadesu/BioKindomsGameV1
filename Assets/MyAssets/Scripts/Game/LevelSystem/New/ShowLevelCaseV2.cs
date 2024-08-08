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
    [SerializeField] protected internal GameObject[] enemy, money, questKing, exitQuest;
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
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                StartCoroutine(LevelTutorialCoroutine());
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 2:
                LevelFight();
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, false, 1, true);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 3:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 4:
                LevelFight();
                questKing[0].SetActive(false);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 5:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 6:
                LevelFight();
                questKing[0].SetActive(false);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 7:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 8:
                LevelFight();
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 9:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 10:
                LevelFight();
                questKing[0].SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 11:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                questKing[0].SetActive(true);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
            case 12:
                platformV2.SetActive(true);
                levelFight.SetActive(false);
                exitQuest[0].SetActive(questLevel._endQuest);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                SaveLevel();
                break;
        }
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
    protected internal void ItemCondition()
    {
        if (loadLevelSystem.inventoryItemDataV2[playerEstanteCol.setId].itemIsCheck)
        {
            NextLevelMethod(true);
        }
        else
        {
            NextLevelMethod(false);
        }
    }
    protected internal void NextLevelMethod(bool _value)
    {
        _NextLevel.SetActive(_value);
        nextLevelAnim.SetBool("nextLevelShow", _value);
    }
}