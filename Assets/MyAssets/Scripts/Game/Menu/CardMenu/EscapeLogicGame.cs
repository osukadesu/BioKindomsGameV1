using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeLogicGame : MonoBehaviour
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

        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 4:
                EscapeFromGame();
                break;
        }

    }
    void EscapeFromGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            mouseController.MouseUnLock();
            menuController.IsNewGame = false;
            menuController.IsLoadGame = false;
            SceneManager.LoadScene(2);
        }
    }
}