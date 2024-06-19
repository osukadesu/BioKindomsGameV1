using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class EscapeLogicProfile : MonoBehaviour
{
    [SerializeField] protected MenuController menuController;
    [SerializeField] protected MouseController mouseController;
    [SerializeField] Button btnBack;
    [SerializeField] Animator alertModalAnimator;
    void Awake()
    {
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
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 2:
                EscapeFromProfile();
                break;
        }
    }
    void ButtonBack()
    {
        menuController.IsMyProfile = false;
        SceneManager.LoadScene(1);
    }
    void EscapeFromProfile()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuController.IsNewGame = false;
            menuController.IsLoadGame = false;
            menuController.IsMyProfile = false;
            mouseController.MouseUnLock();
            SceneManager.LoadScene(1);
        }
    }
}