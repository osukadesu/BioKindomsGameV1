using UnityEngine;
using System.Collections;
using System;
public class LevelWinMethod : MonoBehaviour
{
    [SerializeField] ShowLevelCaseV2 showLevelSystem;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] AlertModalManager alertModalManager;
    void Awake()
    {
        shootLogic = FindObjectOfType<ShootLogic>();
        showLevelSystem = FindObjectOfType<ShowLevelCaseV2>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
    }
    protected internal void WinMethod(int _indexItems, bool _tabAlert)
    {
        shootLogic.canShoot = false;
        showLevelSystem.money[_indexItems].SetActive(true);
        showLevelSystem.pedestal.SetActive(true);
        StartCoroutine(DestroyingEnemy(_indexItems));
        Action action = _tabAlert switch
        {
            true => () => StartCoroutine(TabAlert()),
            false => () => StopCoroutine(TabAlert()),
        };
        action();
    }
    IEnumerator DestroyingEnemy(int _IEenemy)
    {
        yield return new WaitForSeconds(.8f);
        showLevelSystem.enemy[_IEenemy].SetActive(false);
        yield return new WaitForSeconds(2f);
    }
    IEnumerator TabAlert()
    {
        yield return new WaitForSeconds(4f);
        alertModalManager.AlertInfo("Presiona la tecla TAB para ver el inventario.");
    }
}