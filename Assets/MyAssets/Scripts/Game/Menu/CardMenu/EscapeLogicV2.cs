using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EscapeLogicV2 : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected MouseController mouseController;
    [SerializeField] Button btnYes, btnClose, btnBack;
    [SerializeField] Animator alertModalAnimator;
    [SerializeField] bool canEscape;
    public bool CanEscape { get => canEscape; set => canEscape = value; }
    void Awake()
    {
        menuController = FindObjectOfType<MenuController>();
        mouseController = FindObjectOfType<MouseController>();
        btnYes.onClick.AddListener(BtnYesPressed);
        btnClose.onClick.AddListener(StartCloseContinue);
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
        if (canEscape)
        {
            switch (SceneManager.GetActiveScene().buildIndex)
            {
                case 2:
                    EscapeFromProfile();
                    break;
                case 3:
                    EscapeFromGame();
                    break;
                default:
                    break;
            }
        }
    }
    void ButtonBack()
    {
        menuController.IsNewGame = false;
        menuController.IsLoadGame = false;
        SceneManager.LoadScene(1);
    }
    void StartCloseContinue()
    {
        StartCoroutine(CloseContinue());
    }
    IEnumerator CloseContinue()
    {
        alertModalAnimator.SetBool("alertmodal", false);
        yield return new WaitForSeconds(1f);
        mouseController.MouseUnLock();
        menuController.IsNewGame = false;
        menuController.IsLoadGame = false;
        SceneManager.LoadScene(1);
    }
    void BtnYesPressed()
    {
        menuController.IsSavingGame = true;
        SceneManager.LoadScene(3);
    }
    void EscapeFromGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuController.IsNewGame = false;
            menuController.IsLoadGame = false;
            mouseController.MouseUnLock();
            SceneManager.LoadScene(2);
        }
    }
    void EscapeFromProfile()
    {
        string datapath = Application.persistentDataPath + "/player.data";
        if (Input.GetKeyDown(KeyCode.Escape) && !File.Exists(datapath))
        {
            alertModalAnimator.SetBool("alertmodal", true);
        }
    }
}