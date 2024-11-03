using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using UnityEngine.SceneManagement;
public class AlertModalManager : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystem;
    [SerializeField] EscapeLogicGame escapeLogicV1;
    [SerializeField] Text txtInfoAlert, txtAlertNew, txtAlertNewV2;
    [SerializeField] Animator alertModalAnimator, alertModalNew, alertModalNewV2;
    [SerializeField] Button btnContinueAM;
    [SerializeField] GameObject[] imgAlertNew;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
        escapeLogicV1 = FindObjectOfType<EscapeLogicGame>();
        alertModalAnimator.SetBool("alertmodal", false);
        btnContinueAM.onClick.AddListener(() => CloseContinue(levelSystem.CurrentLevel));
    }
    public void ShowTutorialAlerts(int _level)
    {
        Action action = _level switch
        {
            1 => () => StartLevelTutorialCoroutine("¡Hola BioBot! Unos seres invasores han robado algunas reliquias de los reinos biológicos, tu misión es derrotarlos y recuperar las reliquias!", "¡Presiona las teclas y ve a la puerta del reino animal!"),
            2 => () => StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, false, 1, true),
            3 => () =>
            {
                if (!GeneralSingleton.generalSingleton.wasFirtsTime) { StartCoroutine(GoTos("Haz desbloqueado tu perfil presiona continuar para verlo!")); }
            }
            ,
            11 or 12 => () => StartIELevelCaseV2(true, "Felicidades haz completado el reino Animal! \n Ahora ve al reino Vegetal!"),
            22 or 23 => () => StartIELevelCaseV2(true, "Felicidades haz completado el reino Vegetal! \n Ahora ve al reino Fungi!"),
            33 => () => StartIELevelCaseV2(true, "Felicidades haz completado el reino Fungi! \n Ahora ve al reino Protista!"),
            34 => () => FinishDemo("¡Felicidades! Haz completado la demo."),
            44 or 45 => () => StartIELevelCaseV2(true, "Felicidades haz completado el reino Protista! \n Ahora ve al reino Monera!"),
            //55 => () => FinishDemo("¡Felicidades! Haz completado la demo."),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void StartIELevelCase(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2) => StartCoroutine(IELevelCases(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2));
    IEnumerator IELevelCases(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        AlertModalNew(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2);
        yield return new WaitForSeconds(5f);
        AlertModalNew(false, "", indexImg, false, indexImg, false);
    }
    public void StartIELevelCaseV2(bool myBoolAnim, string myText) => StartCoroutine(IELevelCaseV2(myBoolAnim, myText));
    IEnumerator IELevelCaseV2(bool myBoolAnim, string myText)
    {
        AlertModalNewV2(myBoolAnim, myText);
        yield return new WaitForSeconds(5f);
        AlertModalNewV2(false, "");
    }
    public IEnumerator GoTos(string message1)
    {
        AlertInfo(message1);
        yield return new WaitForSeconds(1f);
        GeneralSingleton.generalSingleton.MouseUnLock();
    }
    void StartLevelTutorialCoroutine(string message1, string message2)
    {
        StartCoroutine(LevelTutorialCoroutine(message1, message2));
    }
    void FinishDemo(string message1)
    {
        StartCoroutine(FinishDemoCoroutine(message1));
    }
    IEnumerator FinishDemoCoroutine(string message1)
    {
        yield return new WaitForSeconds(1f);
        GeneralSingleton.generalSingleton.MouseUnLock();
        AlertInfo(message1);
    }
    IEnumerator LevelTutorialCoroutine(string message1, string message2)
    {
        yield return new WaitForSeconds(1f);
        GeneralSingleton.generalSingleton.MouseUnLock();
        AlertInfo(message1);
        yield return new WaitForSeconds(1f);
        AlertModalNew(true, message2, 0, true, 1, false);
        yield return new WaitForSeconds(5f);
        AlertModalNew(false, "", 0, false, 1, false);
    }
    void CloseContinue(int _level)
    {
        ResumeGame();
        escapeLogicV1.CanEscape = true;
        Action action = _level switch
        {
            3 => () =>
                {
                    GeneralSingleton.generalSingleton.isNewGame = false;
                    GeneralSingleton.generalSingleton.isLoadGame = false;
                    GeneralSingleton.generalSingleton.isMyProfile = true;
                    if (GeneralSingleton.generalSingleton.wasFirtsTime)
                    {
                        GeneralSingleton.generalSingleton.isFirtsTime = false;
                    }
                    else
                    {
                        GeneralSingleton.generalSingleton.isFirtsTime = levelSystem.CurrentLevel == 3;
                    }
                    SceneManager.LoadScene(2);
                }
            ,
            /*34 => () => SceneManager.LoadScene(2),*/
            _ => () =>
            {
                GeneralSingleton.generalSingleton.MouseLock();
                alertModalAnimator.SetBool("alertmodal", false);
            }
            ,
        };
        action();
    }
    public void AlertInfo(string textAI) => StartCoroutine(AlertInfoMethod(textAI));
    IEnumerator AlertInfoMethod(string textAIM)
    {
        escapeLogicV1.CanEscape = false;
        GeneralSingleton.generalSingleton.MouseUnLock();
        alertModalAnimator.SetBool("alertmodal", true);
        ShowText(textAIM);
        yield return new WaitForSecondsRealtime(.7f);
        PauseGame();
    }
    void ShowText(string textST)
    {
        txtInfoAlert.fontSize = 22;
        txtInfoAlert.text = textST;
    }
    public void HideText() => alertModalAnimator.SetBool("alertmodal", false);
    void PauseGame() => Time.timeScale = 0f;
    void ResumeGame() => Time.timeScale = 1f;
    public void AlertModalNew(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        alertModalNew.SetBool("alertmodal", myBoolAnim);
        txtAlertNew.text = myText;
        imgAlertNew[indexImg].SetActive(myBoolImg);
        imgAlertNew[indexImg2].SetActive(myBoolImg2);
    }
    public void AlertModalNewV2(bool myBoolAnim, string myText)
    {
        alertModalNewV2.SetBool("alertmodal", myBoolAnim);
        txtAlertNewV2.text = myText;
    }
}