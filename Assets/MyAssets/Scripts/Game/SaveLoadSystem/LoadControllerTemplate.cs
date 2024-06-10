using UnityEngine;
public abstract class LoadControllerTemplate : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected bool levelLoad;
    public bool LevelLoad { get { return levelLoad; } set { levelLoad = value; } }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        LoadControllerMethod();
    }
    protected internal abstract void LoadControllerMethod();
}
