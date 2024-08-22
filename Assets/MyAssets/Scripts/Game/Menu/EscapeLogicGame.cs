using System;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscapeLogicGame : MonoBehaviour
{
    [SerializeField] bool canEscape;
    public bool CanEscape { get => canEscape; set => canEscape = value; }
    void Update()
    {
        EscapeMethod();
    }
    public void EscapeMethod()
    {
        Action action = SceneManager.GetActiveScene().buildIndex switch
        {
            4 => () => EscapeFromGame(),
            _ => () => Debug.Log("EscapeMethod case default!"),
        };
        action();
    }
    void EscapeFromGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GeneralSingleton.generalSingleton.MouseUnLock();
            GeneralSingleton.generalSingleton.isNewGame = false;
            GeneralSingleton.generalSingleton.isLoadGame = false;
            GeneralSingleton.generalSingleton._kingdomIndex = 0;
            SceneManager.LoadScene(2);
        }
    }
}