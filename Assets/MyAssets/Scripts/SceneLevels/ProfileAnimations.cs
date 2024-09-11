using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ProfileAnimations : MonoBehaviour
{
    [SerializeField] Animator[] subUnlockAnim, imgCompleteAnim, txtCompleteAnim, btnResetQuestAnim;
    [SerializeField] Button[] btnResetQuest;
    [SerializeField] GameObject Attention, alertModal;
    [SerializeField] ProfileSystem profileSystem;
    void Awake()
    {
        profileSystem = FindObjectOfType<ProfileSystem>();
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
        Attention.SetActive(GeneralSingleton.generalSingleton.CaseValue is 0 or -1 && !GeneralSingleton.generalSingleton.endQuest[0]);
        alertModal.SetActive(GeneralSingleton.generalSingleton.CaseValue is 0 or -1 && !GeneralSingleton.generalSingleton.endQuest[0] && profileSystem.currentLevel == 11);
    }
    public void SubLevel(int _SubLevelIndex, bool isLoad)
    {
        Action action = isLoad switch
        {
            true => () => subUnlockAnim[_SubLevelIndex].SetBool("subunlockload", true),
            false => () => subUnlockAnim[_SubLevelIndex].SetBool("subunlock", true),
        };
        action();
    }
    public void LevelFinished(int _index, bool isLoad)
    {
        ConditionForShow(_index, isLoad);
    }
    void ConditionForShow(int _index, bool isLoad)
    {
        Action action = isLoad switch
        {
            true => () =>
            {
                imgCompleteAnim[_index].SetBool("imgCompleteLoad", true);
                txtCompleteAnim[_index].SetBool("txtCompleteLoad", true);
                btnResetQuestAnim[_index].SetBool("btnRepiteQuestLoad", true);
            }
            ,
            false => () =>
            {
                imgCompleteAnim[_index].SetBool("imgComplete", true);
                txtCompleteAnim[_index].SetBool("txtComplete", true);
                btnResetQuestAnim[_index].SetBool("btnRepiteQuest", true);
            }
        };
        action();
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