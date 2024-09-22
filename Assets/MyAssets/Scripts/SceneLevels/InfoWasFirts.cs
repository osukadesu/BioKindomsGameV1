using UnityEngine;
using UnityEngine.UI;
public class InfoWasFirts : MonoBehaviour
{
    [SerializeField] Animator cardWas;
    [SerializeField] Button btnContinueAM;
    void Awake()
    {
        btnContinueAM.onClick.AddListener(Close);
        cardWas.SetBool("wasshow", !GeneralSingleton.generalSingleton.wasFirtsTime);
    }
    void Close()
    {
        cardWas.SetBool("wasshow", false);
        if (GeneralSingleton.generalSingleton.isFirtsTime)
        {
            GeneralSingleton.generalSingleton.isFirtsTime = false;
            GeneralSingleton.generalSingleton.wasFirtsTime = true;
            SaveAndLoadManager.SaveFirtsTime(GeneralSingleton.generalSingleton);
        }
    }
}