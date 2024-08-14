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
        btnGoto.gameObject.SetActive(levelSystemV2.CurrentLevel == 11);
        btnGoto.onClick.AddListener(Goto);
    }
    public void Goto()
    {
        MenuController.menuController.IsNewGame = false;
        MenuController.menuController.IsLoadGame = false;
        MenuController.menuController.IsMyProfile = true;
        SceneManager.LoadScene(levelSystemV2.CurrentLevel == 3 ? 2 : 3);
    }
}