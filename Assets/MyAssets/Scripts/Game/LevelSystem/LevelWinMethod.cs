using UnityEngine;
using System.Collections;
public class LevelWinMethod : MonoBehaviour
{
    [SerializeField] ShowLevelSystem showLevelSystem;
    [SerializeField] ShootLogic shootLogic;
    [SerializeField] AlertModalManager alertModalManager;
    void Awake()
    {
        shootLogic = FindObjectOfType<ShootLogic>();
        showLevelSystem = FindObjectOfType<ShowLevelSystem>();
        alertModalManager = FindObjectOfType<AlertModalManager>();
    }
    protected internal void WinMethod(int _indexItems, bool _tabAlert)
    {
        shootLogic.canShoot = false;
        showLevelSystem.money[_indexItems].SetActive(true);
        showLevelSystem.pedestal.SetActive(true);
        StartCoroutine(DestroyingEnemy(_indexItems));
        switch (_tabAlert)
        {
            case true:
                StartCoroutine(TabAlert());
                break;
            case false:
                StopCoroutine(TabAlert());
                break;
        }

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