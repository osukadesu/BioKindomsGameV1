using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BtnNotificationPrefab : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] LoadProfileSingleton loadProfileSingleton;
    [SerializeField] Button btnGoto;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        loadProfileSingleton = FindObjectOfType<LoadProfileSingleton>();
        btnGoto.gameObject.SetActive(levelSystemV2.CurrentLevel is 3);
        btnGoto.onClick.AddListener(Goto);
    }
    public void Goto()
    {
        MenuController.menuController.IsNewGame = false;
        MenuController.menuController.IsLoadGame = false;
        MenuController.menuController.IsMyProfile = true;
        SceneManager.LoadScene(levelSystemV2.CurrentLevel == 3 ? 2 : 3);
        loadProfileSingleton.isFirtsTime = levelSystemV2.CurrentLevel == 3;
        
    }
}