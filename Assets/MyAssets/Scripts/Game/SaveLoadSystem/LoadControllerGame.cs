using UnityEngine;
public class LoadControllerGame : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected bool levelLoadGame;
    public bool LevelLoadGame { get { return levelLoadGame; } set { levelLoadGame = value; } }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        LoadControllerMethod();
    }
    void LoadControllerMethod()
    {
        levelLoadGame = !menuController.IsNewGame && menuController.IsLoadGame;
    }
}