using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject btnLoadGame;
    [SerializeField] MenuController menuController;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] Animator alertDelete;
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        verticalLayoutGroup = GameObject.FindGameObjectWithTag("menuGameVL").GetComponent<VerticalLayoutGroup>();
        btnLoadGame = GameObject.FindGameObjectWithTag("btnLoadGame");
        MenuOrder();
    }
    public void ButtonNewGame()
    {
        string playerData = Application.persistentDataPath + "/player.data";
        Action action = File.Exists(playerData) switch
        {
            true => () => alertDelete.SetBool("alertDelete", true),
            false => () => { menuController.IsNewGame = true; SceneManager.LoadScene(4); }
            ,
        };
        action();
    }
    public void ButtonYes()
    {
        menuController.IsNewGame = true;
        menuController.DeletePlayerData();
        SceneManager.LoadScene(4);
    }
    public void ButtonNo()
    {
        alertDelete.SetBool("alertDelete", false);
    }
    public void ButtonLoadGame()
    {
        menuController.IsLoadGame = true;
        SceneManager.LoadScene(4);
    }
    public void ButtonProfile()
    {
        menuController.IsMyProfile = true;
        SceneManager.LoadScene(3);
    }
    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuOrder()
    {
        string playerData = Application.persistentDataPath + "/player.data";
        bool _fileExist = File.Exists(playerData);
        SetBtnAndLayout(_fileExist, _fileExist ? 0 : 70);
    }
    void SetBtnAndLayout(bool _bool, int _value)
    {
        btnLoadGame.SetActive(_bool);
        verticalLayoutGroup.padding.top = _value;
    }
}