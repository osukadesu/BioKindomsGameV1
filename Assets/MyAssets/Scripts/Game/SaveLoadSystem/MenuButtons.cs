using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject btnLoadGame;
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
        SceneManager.LoadScene(2);
    }
    public void ButtonLoadGame()
    {
        menuController.IsLoadGame = true;
        SceneManager.LoadScene(2);
    }
    public void ButtonOptions()
    {
        //despues. 
    }
    public void ButtonExit()
    {
        Application.Quit();
        menuController.DeleteLevelData();

    }
    public void MenuOrder()
    {
        string datapath = Application.persistentDataPath + "/player.data";
        if (File.Exists(datapath))
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