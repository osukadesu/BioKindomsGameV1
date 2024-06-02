using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class AlertModalManager : MonoBehaviour
{
    [SerializeField] Text txtInfoAlert;
    [SerializeField] Animator alertModalAnimator, alertModal2, alertModal3, alertModal4;
    [SerializeField] MouseController mouseController;
    [SerializeField] EscapeLogicV1 escapeLogicV1;
    [SerializeField] Button btnContinueAM;
    void Awake()
    {
        alertModalAnimator.SetBool("alertmodal", false);
        alertModal2.SetBool("alertmodal", false);
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
        txtInfoAlert.fontSize = 22;
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
    public void AlertModal2(bool mybool)
    {
        alertModal2.SetBool("alertmodal", mybool);
    }
    public void AlertModal3(bool mybool)
    {
        alertModal3.SetBool("alertmodal", mybool);
    }
    public void AlertModal4(bool mybool)
    {
        alertModal4.SetBool("alertmodal", mybool);
    }
}