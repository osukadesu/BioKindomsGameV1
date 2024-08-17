using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ProfileAnimations : MonoBehaviour
{
    [SerializeField] Animator[] subUnlockAnim, imgCompleteAnim, txtCompleteAnim, btnResetQuestAnim;
    [SerializeField] Button[] btnResetQuest;
    [SerializeField] GameObject[] Attention;
    void Awake()
    {
        for (int i = 0; i < btnResetQuest.Length; i++)
        {
            int increment = i;
            btnResetQuest[i].onClick.AddListener(() => AgainQuest(increment));
        }
    }
    void Update()
    {
        ShowAttentionAnimation();
    }
    void ShowAttentionAnimation()
    {
        Attention[0].SetActive(GeneralSingleton.generalSingleton.CaseValue is 0 or -1 && !GeneralSingleton.generalSingleton.endQuest);
        for (int i = 1; i < Attention.Length; i++)
        {
            Attention[i].SetActive(GeneralSingleton.generalSingleton.CaseValue == i && GeneralSingleton.generalSingleton.endQuest);
        }
    }
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlockAnim[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void LevelFinished(int _index)
    {
        StartCoroutine(WaitForShow(_index));
    }
    IEnumerator WaitForShow(int _index)
    {
        imgCompleteAnim[_index].SetBool("imgComplete", true);
        txtCompleteAnim[_index].SetBool("txtComplete", true);
        yield return new WaitForSeconds(1f);
        btnResetQuestAnim[_index].SetBool("btnRepiteQuest", true);
    }
    void AgainQuest(int _btn)
    {
        Action action = _btn switch
        {
            0 => () => GeneralSingleton.generalSingleton.CaseValue = 0,
            1 => () => GeneralSingleton.generalSingleton.CaseValue = 1,
            2 => () => GeneralSingleton.generalSingleton.CaseValue = 2,
            3 => () => GeneralSingleton.generalSingleton.CaseValue = 3,
            4 => () => GeneralSingleton.generalSingleton.CaseValue = 4,
            _ => () => Debug.Log("AgainQuest case default!"),
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