using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EscapeLogicProfile : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected MouseController mouseController;
    [SerializeField] LoadProfileSingleton loadProfileSingleton;
    [SerializeField] Button btnBack;
    [SerializeField] Animator alertModalAnimator;
    void Awake()
    {
        loadProfileSingleton = FindObjectOfType<LoadProfileSingleton>();
        menuController = FindObjectOfType<MenuController>();
        mouseController = FindObjectOfType<MouseController>();
        btnBack.onClick.AddListener(ButtonBack);
    }
    void Start()
    {
        alertModalAnimator.SetBool("alertmodal", false);
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
            _ => () => Debug.Log("Case default!")
        };
        action();
    }
    void ButtonBack()
    {
        loadProfileSingleton.isFirtsTime = false;
        menuController.IsMyProfile = false;
        SceneManager.LoadScene(2);
    }
    void EscapeFromProfile()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuController.IsNewGame = false;
            menuController.IsLoadGame = false;
            menuController.IsMyProfile = false;
            mouseController.MouseUnLock();
            SceneManager.LoadScene(2);
        }
    }
}