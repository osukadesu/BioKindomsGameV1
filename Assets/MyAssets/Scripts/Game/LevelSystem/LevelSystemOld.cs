/*
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class LevelSystemOld : MonoBehaviour
{
    [SerializeField] int currentLevel;
    public int CurrentLevel { get { return currentLevel; } set { currentLevel = value; } }
    [SerializeField] LoadControllerGame loadController;
    [SerializeField] Transform targetPlayerPosition;
    [SerializeField] PlayerMove playerMove;
    [SerializeField] LoadGame loadGame;
    [SerializeField] GameObject[] levels, money, enemies;
    [SerializeField] GameObject plataform, pedestal;
    [SerializeField] TextGralController textGralController;
    [SerializeField] GameObject AlertModal;
    [SerializeField] Text txtInfoAlert;
    [SerializeField] Button btnContinueAM;
    [SerializeField] Animator alertModalAnimator;
    [SerializeField] MouseController mouseController;
    [SerializeField] string textMessage;
    [SerializeField] bool infoAlert;
    void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        mouseController = FindObjectOfType<MouseController>();
        targetPlayerPosition = GameObject.FindGameObjectWithTag("targetPlayer").GetComponent<Transform>();
        loadController = FindObjectOfType<LoadControllerGame>();
        loadGame = FindObjectOfType<LoadGame>();
        textGralController = FindObjectOfType<TextGralController>();
        btnContinueAM.onClick.AddListener(CloseContinue);
        alertModalAnimator.SetBool("alertmodal", false);
    }
    void Start()
    {
        infoAlert = false;
        ReadLevel();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(false);
        }
        PlataformFight1False();
    }
    void PauseGame()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = 0F;
    }
    void ResumeGame()
    {
        if (Time.timeScale != 1.0F)
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }
    void CloseContinue()
    {
        if (infoAlert)
        {
            mouseController.MouseUnLock();
            textGralController.StartingWTLT(currentLevel);
            AlertModal.SetActive(false);
            StartCoroutine(AlertModalFirtsTimePart2());
            ResumeGame();
        }
        else
        {
            AlertModal.SetActive(false);
            mouseController.MouseLock();
        }
    }
    public void ReadLevel()
    {
        if (loadController.LevelLoad)
        {
            PlayerData playerData = SaveAndLoadManager.LoadDataGame();
            currentLevel = playerData.currentLevelData;
            ProcesarNivel(currentLevel);
            Debug.Log("currentLevel = " + currentLevel);
        }
        else
        {
            currentLevel = 0;
            ProcesarNivel(currentLevel);
            Debug.Log("currentLevel = " + currentLevel);
        }
    }
    public void ChangeLevel()
    {
        currentLevel++;
        ProcesarNivel(currentLevel);
        playerMove.transform.position = targetPlayerPosition.position;
    }
    IEnumerator AlertModalFirtsTime()
    {
        mouseController.MouseUnLock();
        txtInfoAlert.fontSize = 25;
        alertModalAnimator.SetBool("alertmodal", true);
        yield return new WaitForSeconds(.5f);
        PauseGame();
    }
    IEnumerator AlertModalFirtsTimePart2()
    {
        yield return new WaitForSeconds(3f);
        textMessage = "Usa las teclas [ W, A, S, D ] para moverte!";
        textGralController.StartingAT(textMessage);
        yield return new WaitForSeconds(4.5f);
        textMessage = "Y la tecla [ Espacio ] para saltar!";
        textGralController.StartingAT(textMessage);
    }
    void TutorialOne()
    {
        AlertModal.SetActive(true);
        alertModalAnimator.SetBool("alertmodal", true);
        txtInfoAlert.fontSize = 25;
        txtInfoAlert.text = "Guarda los tickets sobre los reinos biológicos y completa los niveles. \n Presiona TAB para ver el inventario y crear a los seres vivos.";
    }
    public void ProcesarNivel(int level)
    {
        switch (level)
        {
            case 0:
                SetActiveLevel(0, true);
                LevelCondition();
                AlertModal.SetActive(true);
                StartCoroutine(AlertModalFirtsTime());
                break;
            case 1:
                SetActiveLevel(1, false);
                break;
            case 2:
                SetActiveLevel(2, false);
                textGralController.StartingWTLT(level);
                if (!LevelCondition())
                {
                    TutorialOne();
                }
                break;
            case 3:
                SetActiveLevel(3, false);
                PlataformFight1();
                textGralController.StartingWTLT(level);
                LevelCondition();
                AlertModal.SetActive(false);
                break;
            case 4:
                SetActiveLevel(4, false);
                textGralController.StartingWTLT(level);
                LevelCondition();
                AlertModal.SetActive(false);
                break;
            case 5:
                SetActiveLevel(5, false);
                textGralController.StartingWTLT(level);
                LevelCondition();
                AlertModal.SetActive(false);
                break;
            case 6:
                SetActiveLevel(6, false);
                textGralController.StartingWTLT(level);
                LevelCondition();
                AlertModal.SetActive(false);
                break;
            default:
                NotView();
                PlataformFight1False();
                textMessage = "Error al cargar nivel";
                textGralController.StartingAT(textMessage);
                AlertModal.SetActive(false);
                break;
        }
    }
    public void SetActiveLevel(int _level, bool _infoAlert)
    {
        infoAlert = _infoAlert;
        ShowStaticObjects();
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(i == _level);
        }
    }
    void PlataformFight1()
    {
        money[0].SetActive(true);
        enemies[0].SetActive(true);
        ShowStaticObjects();
    }
    void ShowStaticObjects()
    {
        plataform.SetActive(true);
        pedestal.SetActive(true);
    }
    void PlataformFight1False()
    {
        for (int i = 0; i < money.Length; i++)
        {
            money[i].SetActive(false);
        }
        HideStaticObjects();
    }
    void HideStaticObjects()
    {
        plataform.SetActive(false);
        pedestal.SetActive(false);
    }
    bool LevelCondition()
    {
        if (loadController.LevelLoad)
        {
            PlayerData playerData = SaveAndLoadManager.LoadDataGame();
            loadGame.SettingPlayerPosition(playerData);
            return true;
        }
        return false;
    }
    void NotView()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            levels[i].SetActive(false);
        }
    }
}
/*
Abrir un exe desde el juego.
string textMessage, pathToExe = "C:\\Users\\oscar\\Desktop\\Testing\\BioKindomsGame.exe";
void OpenExecutable()
    {
        System.Diagnostics.Process.Start(pathToExe);
    }
*/