using System.Collections;
using UnityEngine;
public class DeadEnemy : DeadManager
{
    protected internal override void DeadActions()
    {
        DeadActionsSwitch(levelSystem.CurrentLevel);
    }
    void DeadActionsSwitch(int level)
    {
        switch (level)
        {
            case 3:
                DeadActionsMethod(0);
                break;
            case 5:
                DeadActionsMethod(1);
                break;
            case 7:
                DeadActionsMethod(2);
                break;
            case 9:
                DeadActionsMethod(3);
                break;
            case 11:
                DeadActionsMethod(4);
                break;
            case 15:
                DeadActionsMethod(5);
                break;
            case 17:
                DeadActionsMethod(7);
                break;
            case 19:
                DeadActionsMethod(8);
                break;
            case 21:
                DeadActionsMethod(9);
                break;
            case 23:
                DeadActionsMethod(10);
                break;
            case 25:
                DeadActionsMethod(11);
                break;
            case 27:
                DeadActionsMethod(12);
                break;
            case 29:
                DeadActionsMethod(13);
                break;
            case 31:
                DeadActionsMethod(14);
                break;
            case 33:
                DeadActionsMethod(15);
                break;
            case 35:
                DeadActionsMethod(16);
                break;
            case 37:
                DeadActionsMethod(17);
                break;
            case 39:
                DeadActionsMethod(18);
                break;
            case 41:
                DeadActionsMethod(19);
                break;
            case 43:
                DeadActionsMethod(20);
                break;
            case 45:
                DeadActionsMethod(21);
                break;
            case 47:
                DeadActionsMethod(22);
                break;
            case 49:
                DeadActionsMethod(23);
                break;
            case 51:
                DeadActionsMethod(24);
                break;
        }
    }
    void DeadActionsMethod(int _lifeControllerEnemyIndex)
    {
        if (lifeControllerEnemy[_lifeControllerEnemyIndex].currentLife <= 0)
        {
            shootLogic.canShoot = false;
            alertModalManager.AlertInfo("Bien hecho lo has derrotado guarda la moneda y ve al siguiente nivel!");
            WinMethodSwitch(levelSystem.CurrentLevel);
            StartCoroutine(ResetEnemy());
        }
    }
    void WinMethodSwitch(int level)
    {
        switch (level)
        {
            case 3:
                levelWinMethod.WinMethod(0, true);
                break;
            case 5:
                levelWinMethod.WinMethod(1, false);
                break;
            case 7:
                levelWinMethod.WinMethod(2, false);
                break;
            case 9:
                levelWinMethod.WinMethod(3, false);
                break;
            case 11:
                levelWinMethod.WinMethod(4, false);
                break;
            case 13:
                levelWinMethod.WinMethod(5, false);
                break;
            case 15:
                levelWinMethod.WinMethod(6, false);
                break;
            case 17:
                levelWinMethod.WinMethod(7, false);
                break;
            case 19:
                levelWinMethod.WinMethod(8, false);
                break;
            case 21:
                levelWinMethod.WinMethod(9, false);
                break;
            case 23:
                levelWinMethod.WinMethod(10, false);
                break;
            case 25:
                levelWinMethod.WinMethod(11, false);
                break;
            case 27:
                levelWinMethod.WinMethod(12, false);
                break;
            case 29:
                levelWinMethod.WinMethod(13, false);
                break;
            case 31:
                levelWinMethod.WinMethod(14, false);
                break;
            case 33:
                levelWinMethod.WinMethod(15, false);
                break;
            case 35:
                levelWinMethod.WinMethod(16, false);
                break;
            case 37:
                levelWinMethod.WinMethod(17, false);
                break;
            case 39:
                levelWinMethod.WinMethod(18, false);
                break;
            case 41:
                levelWinMethod.WinMethod(19, false);
                break;
            case 43:
                levelWinMethod.WinMethod(20, false);
                break;
            case 45:
                levelWinMethod.WinMethod(21, false);
                break;
            case 47:
                levelWinMethod.WinMethod(22, false);
                break;
            case 49:
                levelWinMethod.WinMethod(23, false);
                break;
            case 51:
                levelWinMethod.WinMethod(24, false);
                break;
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