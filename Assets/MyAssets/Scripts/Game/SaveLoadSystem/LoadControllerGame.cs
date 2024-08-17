using UnityEngine;
public class LoadControllerGame : MonoBehaviour
{
    [SerializeField] protected bool levelLoadGame;
    public bool LevelLoadGame { get { return levelLoadGame; } set { levelLoadGame = value; } }
    void Awake()
    {
        LoadControllerMethod();
    }
    void LoadControllerMethod()
    {
        levelLoadGame = !GeneralSingleton.generalSingleton.isNewGame && GeneralSingleton.generalSingleton.isLoadGame;
    }
}