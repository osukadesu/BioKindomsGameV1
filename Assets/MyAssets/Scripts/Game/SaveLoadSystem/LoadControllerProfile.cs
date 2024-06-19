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
        if (menuController.IsNewGame)
        {
            loadProfile = false;
        }
        if (menuController.IsMyProfile)
        {
            loadProfile = true;
        }
    }
}