using UnityEngine;
public class LoadControllerProfile : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected bool loadProfile;
    public bool LoadProfile { get { return loadProfile; } set { loadProfile = value; } }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        LoadControllerMethod();
    }
    void LoadControllerMethod()
    {
        loadProfile = !menuController.IsNewGame && menuController.IsMyProfile;
    }
}