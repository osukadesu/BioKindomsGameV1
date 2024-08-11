using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ProfileAnimations : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] Animator[] subUnlockAnim, imgCompleteAnim, txtCompleteAnim, btnResetQuestAnim;
    [SerializeField] Button[] btnResetQuest;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        for (int i = 0; i < btnResetQuest.Length; i++)
        {
            int increment = i;
            btnResetQuest[i].onClick.AddListener(() => AgainQuest(increment));
        }
    }
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlockAnim[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void LevelFinished(int _index)
    {
        imgCompleteAnim[_index].SetBool("imgComplete", true);
        txtCompleteAnim[_index].SetBool("txtComplete", true);
        btnResetQuestAnim[_index].SetBool("btnRepiteQuest", true);
    }
    void AgainQuest(int _btn)
    {
        switch (_btn)
        {
            case 0:
                questLevel.CaseValue = 0;
                break;
            case 1:
                questLevel.CaseValue = 1;
                break;
            case 2:
                questLevel.CaseValue = 2;
                break;
            case 3:
                questLevel.CaseValue = 3;
                break;
            case 4:
                questLevel.CaseValue = 4;
                break;
        }
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }
}