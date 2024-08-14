using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] LevelSystemV2 LevelSystemV2;
    [SerializeField] Animator QuestAlertModalAnim;
    [SerializeField] MouseController mouseController;
    [SerializeField] Button btnAcept;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        LevelSystemV2 = FindObjectOfType<LevelSystemV2>();
        mouseController = FindObjectOfType<MouseController>();
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
        mouseController.MouseUnLock();
        yield return new WaitForSecondsRealtime(.8f);
        Time.timeScale = 0f;
    }
    void GoToQuest()
    {
        Time.timeScale = 1f;
        MenuController.menuController.IsMyProfile = true;
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}