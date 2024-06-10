using System.Collections;
using UnityEngine;
public class ShowLevelCaseV2 : MonoBehaviour
{
    [SerializeField] MouseController mouseController;
    [SerializeField] AlertModalManager alertModalManager;
    public void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                StartCoroutine(LevelTutorialCoroutine());
                break;
        }
    }
    IEnumerator LevelTutorialCoroutine()
    {
        mouseController.MouseUnLock();
        alertModalManager.AlertInfo("¡Hola BioBot! Unos seres invasores han robado algunas reliquias de los reinos biológicos, tu misión es derrotarlos y recuperar las reliquias!");
        yield return new WaitForSeconds(1.5f);
        alertModalManager.AlertModal2(true);
        yield return new WaitForSeconds(7f);
        alertModalManager.AlertModal2(false);
    }
}