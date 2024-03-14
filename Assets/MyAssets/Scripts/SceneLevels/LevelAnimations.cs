using UnityEngine;
using UnityEngine.UI;
public class LevelAnimations : MonoBehaviour
{
    [SerializeField] Button[] btnKindom;
    [SerializeField] Animator[] imgCheckUnlock, subUnlock, imageHide, txtUnlock, imgCompleteUnlock, txtHide, imgKindom, imgUnlock, imgHide2;
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlock[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void LevelFinished(int _LevelFinishedIndex)
    {
        btnKindom[_LevelFinishedIndex].interactable = false;
        imgCheckUnlock[_LevelFinishedIndex].SetBool("imgcheckunlock", true);
        imgCompleteUnlock[_LevelFinishedIndex].SetBool("imgcompleteunlock", true);
        txtUnlock[_LevelFinishedIndex].SetBool("txtunlock", true);
        imageHide[_LevelFinishedIndex].SetBool("imghideunlock", true);
        txtHide[_LevelFinishedIndex].SetBool("txthideunlock", true);
        imgKindom[_LevelFinishedIndex].SetBool("imgkindomunlock", true);
        imgUnlock[_LevelFinishedIndex].SetBool("imgunlock", true);
        imgHide2[_LevelFinishedIndex].SetBool("imghide2unlock", true);
    }
}