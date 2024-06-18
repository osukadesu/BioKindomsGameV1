using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeadPlayer : DeadManager
{
    protected internal override void DeadActions()
    {
        if (lifeControllerPlayer.currentLife <= 0)
        {
            StartCoroutine(IEGameOver());
            StartCoroutine(IEChangeScene());
        }
    }
    IEnumerator IEGameOver()
    {
        shootLogic.canShoot = false;
        alertModalManager.AlertInfo("Haz perdido vuelve a internarlo.");
        yield return new WaitForSeconds(.5f);
        lifeControllerPlayer.currentLife = 100;
    }
    IEnumerator IEChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}