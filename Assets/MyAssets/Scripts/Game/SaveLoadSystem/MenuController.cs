using UnityEngine;
public class MenuController : MonoBehaviour
{
    public static MenuController menuController;
    [SerializeField] bool isNewGame, isLoadGame, isSavingGame, isMyProfile;
    public bool IsNewGame { get => isNewGame; set => isNewGame = value; }
    public bool IsLoadGame { get => isLoadGame; set => isLoadGame = value; }
    public bool IsSavingGame { get => isSavingGame; set => isSavingGame = value; }
    public bool IsMyProfile { get => isMyProfile; set => isMyProfile = value; }
    void Awake()
    {
        Singleton(); isNewGame = false; isLoadGame = false; isSavingGame = false; isMyProfile = false;
        Cursor.visible = true; Cursor.lockState = CursorLockMode.None;
    }
    void Singleton()
    {
        if (menuController == null)
        {
            menuController = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}