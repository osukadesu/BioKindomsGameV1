using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] Animator QuestAlertModalAnim;
    [SerializeField] Button btnAcept;
    void Awake()
    {
        btnAcept.onClick.AddListener(GoToQuest);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            QuestAlertModalAnim.SetBool("alertmodal", true);
            StartCoroutine(PauseGame());
        }
    }
    IEnumerator PauseGame()
    {
        GeneralSingleton.generalSingleton.MouseUnLock();
        yield return new WaitForSecondsRealtime(.8f);
        Time.timeScale = 0f;
    }
    void GoToQuest()
    {
        Time.timeScale = 1f;
        GeneralSingleton.generalSingleton.isMyProfile = true;
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}