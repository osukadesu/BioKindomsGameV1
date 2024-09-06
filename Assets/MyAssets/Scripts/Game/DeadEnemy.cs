using System;
using System.Collections;
using UnityEngine;
public class DeadEnemy : DeadManager
{
    protected internal override void DeadActions()
    {
        CaseDeadActionsMethod(levelSystemV2.CurrentLevel);
    }
    void CaseDeadActionsMethod(int _level)
    {
        Action action = _level switch
        {
            2 => () => DeadActionsMethod(true, true, 0),
            4 or 6 or 8 or 10 => () => DeadActionsMethod(true, false, 0),
            13 or 15 or 17 or 19 or 21 => () => DeadActionsMethod(true, false, 1),
            _ => () => DeadActionsMethod(false, false, 1)
        };
        action();
    }
    void DeadActionsMethod(bool value, bool value2, int _case)
    {
        if (value)
        {
            if (lifeControllerEnemy[playerEstanteCol.setId].currentLife <= 0)
            {
                shootLogic.HideNewBullet();
                shootLogic.canShoot = false;
                SetAlertInfo(value2);
                StartCoroutine(IEWinMethod());
                StartCoroutine(ResetEnemy(_case));
            }
        }
    }
    IEnumerator IEWinMethod()
    {
        yield return new WaitForSeconds(.5f);
        levelWinMethod.WinMethod(playerEstanteCol.setId);
    }
    void SetAlertInfo(bool value2)
    {
        if (value2)
        {
            alertModalManager.AlertInfo("Bien hecho lo has derrotado guarda la relíquia!");
        }
        else
        {
            alertModalManager.HideText();
        }
    }
    IEnumerator ResetEnemy(int _case)
    {
        yield return new WaitForSeconds(.5f);
        SetLifeControllerEnemy(_case);
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < lifeControllerEnemy.Length; i++)
        {
            lifeControllerEnemy[i].imgLifeHide.gameObject.SetActive(false);
        }
    }
    void SetLifeControllerEnemy(int _case)
    {
        Action action = _case switch
        {
            0 => () => enemyStateManager[playerEstanteCol.setId].agent.speed = 0,
            _ => () => Debug.Log("Is other kingdom!"),
        };
        action();
        for (int i = 0; i < lifeControllerEnemy.Length; i++)
        {
            lifeControllerEnemy[i].imgLifeHide.gameObject.SetActive(true);
            lifeControllerEnemy[i].currentLife = 100;
        }
    }
}