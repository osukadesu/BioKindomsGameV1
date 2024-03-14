using UnityEngine;
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
                showLevelSystem.LevelPlataforms(1, "¡Presiona [Espacio] para saltar y avanzar al siguiente nivel!", true);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.SaveLevel();
                break;
            case 3:
                showLevelSystem.LevelFight(0, "¡Presiona [Clic izquierdo] para disparar y derrotar al enemigo!", true, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 4:
                showLevelSystem.LevelPlataforms(2, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(1);
                nextLevel.NextLevelCase(1);
                showLevelSystem.SaveLevel();
                break;
            case 5:
                showLevelSystem.LevelFight(1, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 6:
                showLevelSystem.LevelPlataforms(3, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(2);
                nextLevel.NextLevelCase(2);
                showLevelSystem.SaveLevel();
                break;
            case 7:
                showLevelSystem.LevelFight(2, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 8:
                showLevelSystem.LevelPlataforms(4, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(3);
                nextLevel.NextLevelCase(3);
                showLevelSystem.SaveLevel();
                break;
            case 9:
                showLevelSystem.LevelFight(3, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 10:
                showLevelSystem.LevelPlataforms(5, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(4);
                nextLevel.NextLevelCase(4);
                showLevelSystem.SaveLevel();
                break;
            case 11:
                showLevelSystem.LevelFight(4, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 12:
                showLevelSystem.LevelPlataforms(5, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(5);
                showLevelSystem.PlataformGoTo(true);
                showLevelSystem.SaveLevel();
                break;
            case 13:
                showLevelSystem.LevelPlataforms(1, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                nextLevel.NextLevelCase(0);
                showLevelSystem.SaveLevel();
                /*
                showLevelSystem.LevelFight(5, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.PlataformGoTo(true);
                */
                break;
            case 14:
                showLevelSystem.LevelPlataforms(1, null, false);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.SaveLevel();
                break;
            case 15:
                showLevelSystem.LevelFight(6, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 16:
                showLevelSystem.LevelPlataforms(3, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 17:
                showLevelSystem.LevelFight(7, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 18:
                showLevelSystem.LevelPlataforms(4, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 19:
                showLevelSystem.LevelFight(8, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 20:
                showLevelSystem.LevelPlataforms(5, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 21:
                showLevelSystem.LevelFight(9, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 22:
                showLevelSystem.LevelPlataforms(1, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 23:
                showLevelSystem.LevelFight(10, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 24:
                showLevelSystem.LevelPlataforms(2, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 25:
                showLevelSystem.LevelFight(11, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 26:
                showLevelSystem.LevelPlataforms(3, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 27:
                showLevelSystem.LevelFight(12, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 28:
                showLevelSystem.LevelPlataforms(4, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 29:
                showLevelSystem.LevelFight(13, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 30:
                showLevelSystem.LevelPlataforms(5, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 31:
                showLevelSystem.LevelFight(14, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 32:
                showLevelSystem.LevelPlataforms(1, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 33:
                showLevelSystem.LevelFight(15, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 34:
                showLevelSystem.LevelPlataforms(2, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 35:
                showLevelSystem.LevelFight(16, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 36:
                showLevelSystem.LevelPlataforms(3, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 37:
                showLevelSystem.LevelFight(17, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 38:
                showLevelSystem.LevelPlataforms(4, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 39:
                showLevelSystem.LevelFight(18, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 40:
                showLevelSystem.LevelPlataforms(5, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 41:
                showLevelSystem.LevelFight(19, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 42:
                showLevelSystem.LevelPlataforms(1, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 43:
                showLevelSystem.LevelFight(20, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 44:
                showLevelSystem.LevelPlataforms(2, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 45:
                showLevelSystem.LevelFight(21, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 46:
                showLevelSystem.LevelPlataforms(3, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 47:
                showLevelSystem.LevelFight(22, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 48:
                showLevelSystem.LevelPlataforms(4, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 49:
                showLevelSystem.LevelFight(23, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                break;
            case 50:
                showLevelSystem.LevelPlataforms(5, null, false);
                showLevelSystem.SaveLevel();
                break;
            case 51:
                showLevelSystem.LevelFight(24, null, false, 6);
                loadLevelSystem.SetPlayerPositionUnLoad(0);
                showLevelSystem.PlataformGoTo(true);
                break;
            default:
                showLevelSystem.LevelDefault();
                showLevelSystem.PlataformGoTo(false);
                nextLevel.NextLevelCase(0);
                break;
        }
    }
}