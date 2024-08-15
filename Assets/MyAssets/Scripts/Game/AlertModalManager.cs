using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AlertModalManager : MonoBehaviour
{
    [SerializeField] Text txtInfoAlert, txtAlertNew;
    [SerializeField] Animator alertModalAnimator, alertModalNew;
    [SerializeField] MouseController mouseController;
    [SerializeField] EscapeLogicGame escapeLogicV1;
    [SerializeField] Button btnContinueAM;
    [SerializeField] GameObject[] imgAlertNew;
    void Awake()
    {
        alertModalAnimator.SetBool("alertmodal", false);
        btnContinueAM.onClick.AddListener(CloseContinue);
        escapeLogicV1 = FindObjectOfType<EscapeLogicGame>();
    }
    void CloseContinue()
    {
        escapeLogicV1.CanEscape = true;
        mouseController.MouseLock();
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
        mouseController.MouseUnLock();
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