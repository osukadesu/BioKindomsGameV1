using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AlertModalManager : MonoBehaviour
{
    [SerializeField] Text txtInfoAlert;
    [SerializeField] Animator alertModalAnimator;
    [SerializeField] MouseController mouseController;
    [SerializeField] EscapeLogicV1 escapeLogicV1;
    [SerializeField] Button btnContinueAM;
    void Awake()
    {
        alertModalAnimator.SetBool("alertmodal", false);
        btnContinueAM.onClick.AddListener(CloseContinue);
        escapeLogicV1 = FindObjectOfType<EscapeLogicV1>();
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
        yield return new WaitForSecondsRealtime(.6f);
        PauseGame();
    }
    void ShowText(string textST)
    {
        txtInfoAlert.fontSize = 25;
        txtInfoAlert.text = textST;
    }
    protected internal void PauseGame()
    {
        Time.timeScale = 0f;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}