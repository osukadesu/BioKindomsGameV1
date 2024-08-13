using System;
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
        Action action = _btn switch
        {
            0 => () => questLevel.CaseValue = 0,
            1 => () => questLevel.CaseValue = 1,
            2 => () => questLevel.CaseValue = 2,
            3 => () => questLevel.CaseValue = 3,
            4 => () => questLevel.CaseValue = 4,
            _ => () => Debug.Log("Case default!")
        };
        action();
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }
}