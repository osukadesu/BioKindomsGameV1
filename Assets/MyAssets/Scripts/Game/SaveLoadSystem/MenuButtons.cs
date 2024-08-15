using System;
using System.Collections;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject btnLoadGame, btnProfile;
    [SerializeField] MenuController menuController;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] LoadProfileSingleton loadProfileSingleton;
    [SerializeField] Animator alertDelete;
    [SerializeField] Image ImageNotify;
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        loadProfileSingleton = FindObjectOfType<LoadProfileSingleton>();
        verticalLayoutGroup = GameObject.FindGameObjectWithTag("menuGameVL").GetComponent<VerticalLayoutGroup>();
        btnLoadGame = GameObject.FindGameObjectWithTag("btnLoadGame");
        btnProfile = GameObject.FindGameObjectWithTag("btnProfile");
        MenuOrder();
        ImageNotify.gameObject.SetActive(loadProfileSingleton.isFirtsTime);
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
        menuController.DeletePlayerData();
        StartCoroutine(waitSettings());
    }
    IEnumerator waitSettings()
    {
        yield return new WaitForSeconds(.5f);
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
        if (loadProfileSingleton.isFirtsTime)
        {
            loadProfileSingleton.isFirtsTime = false;
            loadProfileSingleton.wasFirtsTime = true;
        }
        menuController.IsMyProfile = true;
        SceneManager.LoadScene(3);
    }
    public void ButtonExit()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuOrder()
    {
        string datapath = Application.persistentDataPath + "/level.data";
        if (File.Exists(datapath))
        {
            btnProfile.SetActive(true);
        }
        else
        {
            (string filePath, GameObject button)[] filebuttonPairs = { ("/player.data", btnLoadGame), ("/score.data", btnProfile) };
            foreach ((string filePath, GameObject button) in filebuttonPairs)
            {
                bool _fileExist = File.Exists(Application.persistentDataPath + filePath);
                SetBtnAndLayout(button, _fileExist);
            }
        }
    }
    void SetBtnAndLayout(GameObject _button, bool _isFile)
    {
        _button.SetActive(_isFile);
        verticalLayoutGroup.padding.top = _isFile ? 0 : 70;
    }
}