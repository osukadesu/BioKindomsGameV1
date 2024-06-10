using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeLogicV1 : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected MouseController mouseController;
    [SerializeField] bool canEscape;
    public bool CanEscape { get => canEscape; set => canEscape = value; }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        mouseController = FindObjectOfType<MouseController>();
    }
    void Update()
    {
        EscapeMethod();
    }
    public void EscapeMethod()
    {
        if (canEscape)
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                    EscapeFromLevelSelect();
                    break;
                case 3:
                    EscapeFromGame();
                    break;
                default:
                    break;
            }
        }
    }
    void EscapeFromGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseController.MouseUnLock();
            SceneManager.LoadScene(1);
        }
    }
    void EscapeFromLevelSelect()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseController.MouseUnLock();
            menuController.IsNewGame = false;
            menuController.IsLoadGame = false;
            SceneManager.LoadScene(1);
        }
    }
}