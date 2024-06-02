using UnityEngine;
using UnityEngine.SceneManagement;
public class ShowLevelCase : MonoBehaviour
{
    [SerializeField] ShowLevelSystem showLevelSystem;
    [SerializeField] LoadLevelSystem loadLevelSystem;
    [SerializeField] NextLevel nextLevel;
    void Awake()
    {
        showLevelSystem = FindObjectOfType<ShowLevelSystem>();
        nextLevel = FindObjectOfType<NextLevel>();
        loadLevelSystem = FindObjectOfType<LoadLevelSystem>();
    }
    void Start()
    {
        showLevelSystem.PlataformGoTo(false);
    }
    protected internal void ShowLevel(int level)
    {
        switch (level)
        {
            case 1:
                showLevelSystem.LevelTutorial(0);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.SaveLevel();
                break;
            case 2:
                showLevelSystem.LevelPlataforms(1, 1);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.SaveLevel();
                break;
            case 3:
                showLevelSystem.LevelFight(0, 2, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 4:
                showLevelSystem.LevelPlataforms(2, 0);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                nextLevel.NextLevelCase(1);
                showLevelSystem.SaveLevel();
                break;
            case 5:
                showLevelSystem.LevelFight(1, 0, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 6:
                showLevelSystem.LevelPlataforms(3, 0);
                loadLevelSystem.SetPlayerPositionUnLoad(2);
                nextLevel.NextLevelCase(2);
                showLevelSystem.SaveLevel();
                break;
            case 7:
                showLevelSystem.LevelFight(2,0, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 8:
                showLevelSystem.LevelPlataforms(4, 0);
                loadLevelSystem.SetPlayerPositionUnLoad(3);
                nextLevel.NextLevelCase(3);
                showLevelSystem.SaveLevel();
                break;
            case 9:
                showLevelSystem.LevelFight(3, 0, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 10:
                showLevelSystem.LevelPlataforms(5, 0);
                loadLevelSystem.SetPlayerPositionUnLoad(4);
                nextLevel.NextLevelCase(4);
                showLevelSystem.SaveLevel();
                break;
            case 11:
                showLevelSystem.LevelFight(4, 0, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 12:
                showLevelSystem.LevelPlataforms(5, 0);
                loadLevelSystem.SetPlayerPositionUnLoad(5);
                showLevelSystem.PlataformGoTo(true);
                showLevelSystem.SaveLevel();
                break;
            case 13:
            SceneManager.LoadScene(2);
                break;
            default:
                showLevelSystem.LevelDefault();
                showLevelSystem.PlataformGoTo(false);
                nextLevel.NextLevelCase(0);
                break;
        }
    }
}