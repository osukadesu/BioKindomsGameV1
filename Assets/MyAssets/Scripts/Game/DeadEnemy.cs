using System;
using System.Collections;
using UnityEngine;
public class DeadEnemy : DeadManager
{
    protected internal override void DeadActions()
    {
        CaseDeadActionsMethod(levelSystemV2.CurrentLevel);
    }
    void CaseDeadActionsMethod(int value)
    {
        Action action = value switch
        {
            2 => () => DeadActionsMethod(true, true),
            4 or 6 or 8 or 10 or 13 or 15 => () => DeadActionsMethod(true, false),
            _ => () => DeadActionsMethod(false, false)
        };
        action();
    }
    void DeadActionsMethod(bool value, bool value2)
    {
        if (value)
        {
            if (lifeControllerEnemy[playerEstanteCol.setId].currentLife <= 0)
            {
                shootLogic.canShoot = false;
                SetAlertInfo(value2);
                StartCoroutine(IEWinMethod());
                StartCoroutine(ResetEnemy());
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
    IEnumerator ResetEnemy()
    {
        yield return new WaitForSeconds(.5f);
        SetLifeControllerEnemy();
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < lifeControllerEnemy.Length; i++)
        {
            lifeControllerEnemy[i].imgLifeHide.gameObject.SetActive(false);
        }
    }
    void SetLifeControllerEnemy()
    {
        for (int i = 0; i < lifeControllerEnemy.Length; i++)
        {
            enemyStateManager.agent.speed = 0;
            lifeControllerEnemy[i].imgLifeHide.gameObject.SetActive(true);
            lifeControllerEnemy[i].currentLife = 100;
        }
    }
}