using System.IO;
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
        switch (File.Exists(playerData))
        {
            case true:
                alertDelete.SetBool("alertDelete", true);
                break;
            case false:
                menuController.IsNewGame = true;
                SceneManager.LoadScene(4);
                break;
        }
    }
    public void ButtonYes()
    {
        menuController.IsNewGame = true;
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
        menuController.DeletePlayerData();
    }
    public void MenuOrder()
    {
        string playerData = Application.persistentDataPath + "/player.data";
        if (File.Exists(playerData))
        {
            btnLoadGame.SetActive(true);
            verticalLayoutGroup.padding.top = 0;
        }
        else
        {
            btnLoadGame.SetActive(false);
            verticalLayoutGroup.padding.top = 70;
        }
    }
}