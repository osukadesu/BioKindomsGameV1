using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EscapeLogicProfile : MonoBehaviour
{
    [SerializeField] Button btnBack;
    void Awake()
    {
        btnBack.onClick.AddListener(ButtonBack);
    }
    void Update()
    {
        EscapeMethod();
    }
    public void EscapeMethod()
    {
        Action action = SceneManager.GetActiveScene().buildIndex switch
        {
            3 => () => EscapeFromProfile(),
            _ => () => Debug.Log("EscapeMethod case default!"),
        };
        action();
    }
    void ButtonBack()
    {
        GeneralSingleton.generalSingleton.isFirtsTime = false;
        GeneralSingleton.generalSingleton.isMyProfile = false;
        SceneManager.LoadScene(2);
    }
    void EscapeFromProfile()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GeneralSingleton.generalSingleton.isNewGame = false;
            GeneralSingleton.generalSingleton.isLoadGame = false;
            GeneralSingleton.generalSingleton.isMyProfile = false;
            GeneralSingleton.generalSingleton.MouseUnLock();
            SceneManager.LoadScene(2);
        }
    }
}