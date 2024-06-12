using System.Collections;
using UnityEngine;
public class ShowLevelCaseV2 : MonoBehaviour
{
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] MouseController mouseController;
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] GameObject levelFight;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] SaveMethod saveMethod;
    [SerializeField] GameObject _NextLevel;
    [SerializeField] Animator nextLevelAnim;
    [SerializeField] protected internal GameObject[] enemy, money;
    [SerializeField] protected internal GameObject pedestal;
    [SerializeField] bool isNextLevel;
    public void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                StartCoroutine(LevelTutorialCoroutine());
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                SaveLevel();
                break;
            case 2:
                StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, true);
                LevelFight(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                SaveLevel();
                break;
            case 3:
                ItemCondition(0);
                break;
        }
    }
    IEnumerator LevelTutorialCoroutine()
    {
        mouseController.MouseUnLock();
        alertModalManager.AlertInfo("¡Hola BioBot! Unos seres invasores han robado algunas reliquias de los reinos biológicos, tu misión es derrotarlos y recuperar las reliquias!");
        yield return new WaitForSeconds(1f);
        alertModalManager.AlertModalNew(true, "¡Presiona las teclas y ve a la puerta del reino animal!", 0, true);
        yield return new WaitForSeconds(5f);
        alertModalManager.AlertModalNew(false, "", 0, false);
    }
    void StartIELevelCase(bool myBoolAnim, string myText, int indexImg, bool myBoolImg)
    {
        StartCoroutine(IELevelCases(myBoolAnim, myText, indexImg, myBoolImg));
    }
    IEnumerator IELevelCases(bool myBoolAnim, string myText, int indexImg, bool myBoolImg)
    {
        alertModalManager.AlertModalNew(myBoolAnim, myText, indexImg, myBoolImg);
        yield return new WaitForSeconds(5f);
        alertModalManager.AlertModalNew(false, "", indexImg, false);
    }
    protected internal void LevelFight(int _idenxItems)
    {
        SetLevel(true);
        NextLevelMethod(false, false);
        isNextLevel = false;
        enemy[_idenxItems].SetActive(true);
        money[_idenxItems].SetActive(false);
        pedestal.SetActive(false);
        saveMethod._EnableBtnSave = false;
    }
    void SetLevel(bool _canShoot)
    {
        StartCoroutine(IECanshot(_canShoot));
        levelFight.SetActive(true);
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
        yield return new WaitForSeconds(.6f);
        saveMethod.SaveLevel();
        Debug.Log("Partida Guardada!");
    }
    protected internal void ItemCondition(int itemIndex)
    {
        if (loadLevelSystem.IOAS[itemIndex].IsNextLevel)
        {
            NextLevelMethod(true, true);
        }
        else
        {
            NextLevelMethod(false, false);
        }
    }
    protected internal void NextLevelMethod(bool _value, bool boolAnim)
    {
        _NextLevel.SetActive(_value);
        nextLevelAnim.SetBool("nextLevelShow", boolAnim);
    }
}