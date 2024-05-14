using UnityEngine;
public abstract class LoadControllerTemplate : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    //[SerializeField] protected LoadGame loadGame;
    [SerializeField] protected bool levelLoad;
    public bool LevelLoad { get { return levelLoad; } set { levelLoad = value; } }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        //loadGame = FindObjectOfType<LoadGame>();
        LoadControllerMethod();
    }
    protected internal abstract void LoadControllerMethod();
}
