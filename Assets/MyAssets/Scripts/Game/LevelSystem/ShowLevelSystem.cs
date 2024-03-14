using UnityEngine;
using System.Collections;
public class ShowLevelSystem : MonoBehaviour
{
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] NextLevel nextLevel;
    [SerializeField] MouseController mouseController;
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] protected internal GameObject[] levels, enemy, money;
    [SerializeField] protected internal GameObject pedestal, plataformQuest;
    [SerializeField] bool isNextLevel;
    void Awake()
    {
        nextLevel = FindObjectOfType<NextLevel>();
        saveMethod = FindObjectOfType<SaveMethod>();
        mouseController = FindObjectOfType<MouseController>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
        shootLogic = FindObjectOfType<ShootLogic>();
    }
    public void SaveLevel()
    {
        StartCoroutine(IESaveLevel());
    }
    IEnumerator IESaveLevel()
    {
        yield return new WaitForSeconds(.6f);
        saveMethod.SaveLevel();
        Debug.Log("Partida Guardada!");
    }
    protected internal void LevelDefault()
    {
        HideLevel();
        alertModalManager.AlertInfo("Error al cargar el nivel.");
    }
    void HideLevel()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
    }
    protected internal void LevelTutorial(int _nextLevel)
    {
        SetLevel(0, false);
        isNextLevel = true;
        nextLevel.NextLevelMethod(_nextLevel, true, "nextLevelShow", true);
        StartCoroutine(LevelTutorialCoroutine());
        saveMethod._EnableBtnSave = false;
    }
    IEnumerator LevelTutorialCoroutine()
    {
        mouseController.MouseUnLock();
        alertModalManager.AlertInfo("¡Hola bienvenido a BioKindomsGame aprendamos mientras nos divertimos!");
        yield return new WaitForSeconds(.7f);
        mouseController.MouseUnLock();
        alertModalManager.AlertInfo("¡Presiona [ W, A, S, D ] y avanza al siguiente nivel!");
    }
    protected internal void LevelPlataforms(int _nextLevel, string _alertInfo, bool _needAlert)
    {
        SetLevel(1, false);
        isNextLevel = true;
        nextLevel.NextLevelMethod(_nextLevel, true, "nextLevelShow", true);
        SwitchAlertInfo(_alertInfo, _needAlert);
        saveMethod._EnableBtnSave = true;
    }
    protected internal void LevelFight(int _idenxItems, string _alertInfo, bool _needAlert, int _nextLevel)
    {
        SetLevel(2, true);
        nextLevel.NextLevelMethod(_nextLevel, false, "nextLevelShow", false);
        isNextLevel = false;
        enemy[_idenxItems].SetActive(true);
        money[_idenxItems].SetActive(false);
        pedestal.SetActive(false);
        SwitchAlertInfo(_alertInfo, _needAlert);
        saveMethod._EnableBtnSave = false;
    }
    void SetLevel(int _level, bool _canShoot)
    {
        StartCoroutine(IECanshot(_canShoot));
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == _level);
        }
    }
    IEnumerator IECanshot(bool _canShoot)
    {
        yield return new WaitForSeconds(1f);
        shootLogic.canShoot = _canShoot;
    }
    void SwitchAlertInfo(string _alertInfo, bool _needAlert)
    {
        switch (_needAlert)
        {
            case true:
                alertModalManager.AlertInfo(_alertInfo);
                break;
            case false:
                break;
        }
    }
    protected internal void PlataformGoTo(bool _setBool)
    {
        switch (_setBool)
        {
            case true:
                plataformQuest.SetActive(true);
                nextLevel.NextLevelMethod(7, true, "nextLevelShow", true);
                break;
            case false:
                plataformQuest.SetActive(false);
                nextLevel.NextLevelMethod(7, false, "nextLevelShow", false);
                break;
        }
    }
}