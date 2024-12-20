using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    [SerializeField] GameObject btnLoadGame, btnProfile, blockRaycast;
    [SerializeField] VerticalLayoutGroup verticalLayoutGroup;
    [SerializeField] Animator alertDelete;
    [SerializeField] Image ImageNotify;
    void Awake()
    {
        verticalLayoutGroup = GameObject.FindGameObjectWithTag("menuGameVL").GetComponent<VerticalLayoutGroup>();
        btnLoadGame = GameObject.FindGameObjectWithTag("btnLoadGame");
        btnProfile = GameObject.FindGameObjectWithTag("btnProfile");
        MenuOrder();
        ImageNotify.gameObject.SetActive(GeneralSingleton.generalSingleton.isFirtsTime);
        blockRaycast.gameObject.SetActive(GeneralSingleton.generalSingleton.isFirtsTime);
    }
    public void ButtonNewGame()
    {
        string playerData = Application.persistentDataPath + "/player.data";
        Action action = File.Exists(playerData) switch
        {
            true => () => alertDelete.SetBool("alertDelete", true),
            false => () => { GeneralSingleton.generalSingleton.isNewGame = true; SceneManager.LoadScene(4); }
            ,
        };
        action();
    }
    public void ButtonYes()
    {
        DeletePlayerData();
        StartCoroutine(waitSettings());
    }
    void DeletePlayerData()
    {
        string[] fileNames = { Application.persistentDataPath + "/player.data", Application.persistentDataPath + "/level.data",
        Application.persistentDataPath + "/quest.data", Application.persistentDataPath + "/score.data", Application.persistentDataPath + "/FirtsTime.data" };
        for (int i = 0; i < fileNames.Length; i++)
        {
            if (File.Exists(fileNames[i]))
            {
                File.Delete(fileNames[i]);
            }
        }
    }
    IEnumerator waitSettings()
    {
        yield return new WaitForSeconds(.5f);
        GeneralSingleton.generalSingleton.isNewGame = true;
        SceneManager.LoadScene(4);
    }
    public void ButtonNo() => alertDelete.SetBool("alertDelete", false);
    public void ButtonLoadGame()
    {
        GeneralSingleton.generalSingleton.isLoadGame = true;
        SceneManager.LoadScene(4);
    }
    public void ButtonProfile()
    {
        GeneralSingleton.generalSingleton.isLoadGame = false;
        GeneralSingleton.generalSingleton.isMyProfile = true;
        SceneManager.LoadScene(3);
    }
    public void ButtonExit() => SceneManager.LoadScene(1);
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