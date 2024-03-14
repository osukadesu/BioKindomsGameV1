using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ExitLevelSelect : MonoBehaviour
{
    [SerializeField] LevelController _levelController;
    [SerializeField] Button btnExitLevel;
    void Awake()
    {
        btnExitLevel.onClick.AddListener(() => _levelController.ButtonExitLevel());
    }
    public void Configure(LevelController levelController)
    {
        _levelController = levelController;
    }
    public void ExitLevel()
    {
        SceneManager.LoadScene(1);
    }
}