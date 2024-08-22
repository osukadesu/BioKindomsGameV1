using UnityEngine;
using System.Collections;
public class LevelWinMethod : MonoBehaviour
{
    [SerializeField] LevelDisplay levelDisplay;
    [SerializeField] ShootLogic shootLogic;
    void Awake()
    {
        shootLogic = FindObjectOfType<ShootLogic>();
        levelDisplay = FindObjectOfType<LevelDisplay>();
    }
    protected internal void WinMethod(int _indexItems)
    {
        shootLogic.canShoot = false;
        levelDisplay.money[_indexItems].SetActive(true);
        levelDisplay.pedestalAnim.SetBool("pedestalShow", true);
        StartCoroutine(DestroyingEnemy(_indexItems));
    }
    IEnumerator DestroyingEnemy(int _IEenemy)
    {
        yield return new WaitForSeconds(.8f);
        levelDisplay.enemy[_IEenemy].SetActive(false);
        yield return new WaitForSeconds(2f);
    }
}