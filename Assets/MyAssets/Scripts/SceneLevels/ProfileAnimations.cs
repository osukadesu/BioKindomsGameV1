using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ProfileAnimations : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] Animator[] subUnlock, imgComplete, txtComplete, imgRepiteQuest;
    [SerializeField] Button[] btnRepiteQuest;
    void Awake()
    {
        for (int i = 0; i < btnRepiteQuest.Length; i++)
        {
            btnRepiteQuest[i].onClick.AddListener(AgainQuest);
        }
    }
    void Start()
    {
        for (int i = 0; i < btnRepiteQuest.Length; i++)
        {
            btnRepiteQuest[i].enabled = false;
        }
    }
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlock[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void LevelFinished(int _index)
    {
        btnRepiteQuest[_index].enabled = true;
        imgComplete[_index].SetBool("imgComplete", true);
        txtComplete[_index].SetBool("txtComplete", true);
        imgRepiteQuest[_index].SetBool("imgRepiteQuest", true);
        /*
         imgCheckUnlock[_index].SetBool("imgcheckunlock", true);
         imageHide[_index].SetBool("imghideunlock", true);
         txtHide[_index].SetBool("txthideunlock", true);
         imgKindom[_index].SetBool("imgkindomunlock", true);
         imgUnlock[_index].SetBool("imgunlock", true);
         imgHide2[_index].SetBool("imghide2unlock", true);
        */
    }
    void AgainQuest(int _btn)
    {
        switch (_btn)
        {
            case 0:
                questLevel.CaseValue = 1;
                break;
            case 1:
                questLevel.CaseValue = 2;
                break;
            case 2:
                questLevel.CaseValue = 3;
                break;
            case 3:
                questLevel.CaseValue = 4;
                break;
            case 4:
                questLevel.CaseValue = 5;
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