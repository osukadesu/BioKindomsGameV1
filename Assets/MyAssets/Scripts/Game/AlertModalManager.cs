using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
public class AlertModalManager : MonoBehaviour
{
    [SerializeField] Text txtInfoAlert, txtAlertNew;
    [SerializeField] Animator alertModalAnimator, alertModalNew;
    [SerializeField] EscapeLogicGame escapeLogicV1;
    [SerializeField] Button btnContinueAM;
    [SerializeField] GameObject[] imgAlertNew;
    void Awake()
    {
        alertModalAnimator.SetBool("alertmodal", false);
        btnContinueAM.onClick.AddListener(CloseContinue);
        escapeLogicV1 = FindObjectOfType<EscapeLogicGame>();
    }
    public void ShowTutorialAlerts(int _case)
    {
        Action action = _case switch
        {
            1 => () => StartCoroutine(LevelTutorialCoroutine()),
            2 => () => StartIELevelCase(true, "Presiona el Clic izquierdo para disparar y derrotar al enemigo.", 0, false, 1, true),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    void StartIELevelCase(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        StartCoroutine(IELevelCases(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2));
    }
    IEnumerator IELevelCases(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        AlertModalNew(myBoolAnim, myText, indexImg, myBoolImg, indexImg2, myBoolImg2);
        yield return new WaitForSeconds(5f);
        AlertModalNew(false, "", indexImg, false, indexImg, false);
    }
    IEnumerator LevelTutorialCoroutine()
    {
        yield return new WaitForSeconds(1f);
        GeneralSingleton.generalSingleton.MouseUnLock();
        AlertInfo("¡Hola BioBot! Unos seres invasores han robado algunas reliquias de los reinos biológicos, tu misión es derrotarlos y recuperar las reliquias!");
        yield return new WaitForSeconds(1f);
        AlertModalNew(true, "¡Presiona las teclas y ve a la puerta del reino animal!", 0, true, 1, false);
        yield return new WaitForSeconds(5f);
        AlertModalNew(false, "", 0, false, 1, false);
    }
    void CloseContinue()
    {
        escapeLogicV1.CanEscape = true;
        GeneralSingleton.generalSingleton.MouseLock();
        alertModalAnimator.SetBool("alertmodal", false);
        ResumeGame();
    }
    protected internal void AlertInfo(string textAI)
    {
        StartCoroutine(AlertInfoMethod(textAI));
    }
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
    protected internal void HideText()
    {
        alertModalAnimator.SetBool("alertmodal", false);
    }
    protected internal void PauseGame()
    {
        Time.timeScale = 0f;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void AlertModalNew(bool myBoolAnim, string myText, int indexImg, bool myBoolImg, int indexImg2, bool myBoolImg2)
    {
        alertModalNew.SetBool("alertmodal", myBoolAnim);
        txtAlertNew.text = myText;
        imgAlertNew[indexImg].SetActive(myBoolImg);
        imgAlertNew[indexImg2].SetActive(myBoolImg2);
    }
}