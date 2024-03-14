using UnityEngine;
public class LevelController : MonoBehaviour
{
    [SerializeField] ExitLevelSelect exitLevelSelect;
    [SerializeField] LevelSelect levelSelect;
    void Awake()
    {
        exitLevelSelect.Configure(this);
        levelSelect.Configure(this);
    }
    public void ButtonExitLevel()
    {
        exitLevelSelect.ExitLevel();
    }
    public void ButtonGoGame()
    {
        levelSelect.GoGame();
    }
}