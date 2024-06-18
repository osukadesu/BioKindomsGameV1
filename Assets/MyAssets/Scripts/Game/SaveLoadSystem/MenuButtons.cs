using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject btnLoadGame, btnMyProfile;
    [SerializeField] MenuController menuController;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        verticalLayoutGroup = GameObject.FindGameObjectWithTag("menuGameVL").GetComponent<VerticalLayoutGroup>();
        btnLoadGame = GameObject.FindGameObjectWithTag("btnLoadGame");
        MenuOrder();
    }
    public void ButtonNewGame()
    {
        menuController.IsNewGame = true;
        SceneManager.LoadScene(3);
    }
    public void ButtonLoadGame()
    {
        menuController.IsLoadGame = true;
        SceneManager.LoadScene(3);
    }
    public void ButtonProfile()
    {
        SceneManager.LoadScene(2);
    }
    public void ButtonExit()
    {
        Application.Quit();
        menuController.DeleteLevelData();
    }
    public void MenuOrder()
    {
        string datapath = Application.persistentDataPath + "/levelgame.data";
        if (File.Exists(datapath))
        {
            btnLoadGame.SetActive(true);
            btnMyProfile.SetActive(true);
            verticalLayoutGroup.padding.top = 0;
        }
        else
        {
            btnLoadGame.SetActive(false);
            btnMyProfile.SetActive(false);
            verticalLayoutGroup.padding.top = 145;
        }
    }
}