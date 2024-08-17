using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BtnNotificationPrefab : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] Button btnGoto;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        btnGoto.gameObject.SetActive(levelSystemV2.CurrentLevel is 3);
        btnGoto.onClick.AddListener(Goto);
    }
    public void Goto()
    {
        GeneralSingleton.generalSingleton.isNewGame = false;
        GeneralSingleton.generalSingleton.isLoadGame = false;
        GeneralSingleton.generalSingleton.isMyProfile = true;
        SceneManager.LoadScene(levelSystemV2.CurrentLevel == 3 ? 2 : 3);
        if (GeneralSingleton.generalSingleton.wasFirtsTime)
        {
            GeneralSingleton.generalSingleton.isFirtsTime = false;
        }
        else
        {
            GeneralSingleton.generalSingleton.isFirtsTime = levelSystemV2.CurrentLevel == 3;
        }
    }
}