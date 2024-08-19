using UnityEngine;
using System.Collections;
public class LevelWinMethod : MonoBehaviour
{
    [SerializeField] ShowLevelCaseV2 showLevelSystem;
    [SerializeField] ShootLogic shootLogic;
    void Awake()
    {
        shootLogic = FindObjectOfType<ShootLogic>();
        showLevelSystem = FindObjectOfType<ShowLevelCaseV2>();
    }
    protected internal void WinMethod(int _indexItems)
    {
        shootLogic.canShoot = false;
        showLevelSystem.money[_indexItems].SetActive(true);
        showLevelSystem.pedestalAnim.SetBool("pedestalShow", true);
        StartCoroutine(DestroyingEnemy(_indexItems));
    }
    IEnumerator DestroyingEnemy(int _IEenemy)
    {
        yield return new WaitForSeconds(.8f);
        showLevelSystem.enemy[_IEenemy].SetActive(false);
        yield return new WaitForSeconds(2f);
    }
}