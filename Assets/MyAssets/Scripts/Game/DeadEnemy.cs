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
        switch (value)
        {
            case 2:
                DeadActionsMethod(true, true);
                break;
            case 4:
                DeadActionsMethod(true, false);
                break;
            case 6:
                DeadActionsMethod(true, false);
                break;
            case 8:
                DeadActionsMethod(true, false);
                break;
            case 10:
                DeadActionsMethod(true, false);
                break;
            case 13:
                DeadActionsMethod(true, false);
                break;
            default:
                DeadActionsMethod(false, false);
                break;
        }
    }
    void DeadActionsMethod(bool value, bool value2)
    {
        if (value)
        {
            if (lifeControllerEnemy[playerEstanteCol.setId].currentLife <= 0)
            {
                shootLogic.canShoot = false;
                ForAlertInfo(value2);
                levelWinMethod.WinMethod(playerEstanteCol.setId, value2);
                StartCoroutine(ResetEnemy());
            }
        }
    }
    void ForAlertInfo(bool value2)
    {
        if (value2)
        {
            alertModalManager.AlertInfo("Bien hecho lo has derrotado guarda la relíquia!");
        }
    }
    IEnumerator ResetEnemy()
    {
        yield return new WaitForSeconds(.5f);
        ForLifeControllerEnemy();
    }
    void ForLifeControllerEnemy()
    {
        for (int i = 0; i < lifeControllerEnemy.Length; i++)
        {
            lifeControllerEnemy[i].currentLife = 100;
        }
    }
}