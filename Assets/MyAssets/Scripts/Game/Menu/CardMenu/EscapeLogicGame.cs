using System;
using UnityEditor.PackageManager;
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
        Action action = SceneManager.GetActiveScene().buildIndex switch
        {
            4 => () => EscapeFromGame(),
            _ => () => Debug.LogError("Value Error!"),
        };
        action();
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