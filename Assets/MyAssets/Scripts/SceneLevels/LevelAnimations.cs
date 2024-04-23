using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class LevelAnimations : MonoBehaviour
{
    [SerializeField] Button[] btnKindom;
    [SerializeField] Animator[] imgCheckUnlock, subUnlock, imageHide, txtUnlock, imgCompleteUnlock, txtHide, imgKindom, imgUnlock, imgHide2, btnCardRotate;
    [SerializeField] Animator imgInfo, imgQuest, btnInfo, btnQuest;
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlock[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void QuestFinish(int _index)
    {
        StartCoroutine(IEWait(_index));
    }
    public void LevelFinished(int _index, bool canRotate)
    {
        btnKindom[_index].enabled = false;
        imgCheckUnlock[_index].SetBool("imgcheckunlock", true);
        imgCompleteUnlock[_index].SetBool("imgcompleteunlock", true);
        txtUnlock[_index].SetBool("txtunlock", true);
        imageHide[_index].SetBool("imghideunlock", true);
        txtHide[_index].SetBool("txthideunlock", true);
        imgKindom[_index].SetBool("imgkindomunlock", true);
        imgUnlock[_index].SetBool("imgunlock", true);
        imgHide2[_index].SetBool("imghide2unlock", true);
        if (canRotate)
        {
            StartCoroutine(IEBtnCardRotate());
        }
        /*
        switch (_version)
        {
            case 0:
                btnKindom[_index].interactable = false;
                imgCheckUnlock[_index].SetBool("imgcheckunlock", true);
                imgCompleteUnlock[_index].SetBool("imgcompleteunlock", true);
                txtUnlock[_index].SetBool("txtunlock", true);
                imageHide[_index].SetBool("imghideunlock", true);
                txtHide[_index].SetBool("txthideunlock", true);
                imgKindom[_index].SetBool("imgkindomunlock", true);
                imgUnlock[_index].SetBool("imgunlock", true);
                imgHide2[_index].SetBool("imghide2unlock", true);
                break;
            case 1:
                btnKindom[_index].interactable = false;
                imgKindom[_index].SetBool("imgkindomunlock", true);
                imgUnlock[_index].SetBool("imgunlock", true);
                break;
        }
        */
    }
    public void OtherAnims(int _indexBtn, string type)
    {
        for (int i = _indexBtn; i < btnKindom.Length; i++)
        {
            btnKindom[i].enabled = false;
        }
        switch (type)
        {
            case "quest":
                btnQuest.SetBool("questShow", true);
                imgQuest.SetBool("imgkindomunlock", true);
                break;
            case "info":
                btnInfo.SetBool("questShow", true);
                imgInfo.SetBool("imgkindomunlock", true);
                btnQuest.SetBool("questShow", false);
                imgQuest.SetBool("imgkindomunlock", false);
                break;
        }
    }
    IEnumerator IEBtnCardRotate()
    {
        yield return new WaitForSeconds(3f);
        btnCardRotate[0].SetBool("btnCardRotate", true);
    }
    IEnumerator IEWait(int index)
    {
        yield return new WaitForSeconds(6f);
        imgCheckUnlock[index].SetBool("imgcheckunlock", true);
        imgCompleteUnlock[index].SetBool("imgcompleteunlock", true);
        txtUnlock[index].SetBool("txtunlock", true);
        yield return new WaitForSeconds(4f);
        btnCardRotate[1].SetBool("questRotate", true);
    }
}