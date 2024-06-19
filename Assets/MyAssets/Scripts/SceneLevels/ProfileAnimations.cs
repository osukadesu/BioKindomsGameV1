using UnityEngine;
public class ProfileAnimations : MonoBehaviour
{
    [SerializeField] Animator[] imgCheckUnlock, subUnlock, imageHide, txtUnlock, imgCompleteUnlock, txtHide, imgKindom, imgUnlock, imgHide2;
    public void SubLevel(int _SubLevelIndex)
    {
        subUnlock[_SubLevelIndex].SetBool("subunlock", true);
    }
    public void LevelFinished(int _index)
    {
        imgCheckUnlock[_index].SetBool("imgcheckunlock", true);
        imgCompleteUnlock[_index].SetBool("imgcompleteunlock", true);
        txtUnlock[_index].SetBool("txtunlock", true);
        imageHide[_index].SetBool("imghideunlock", true);
        txtHide[_index].SetBool("txthideunlock", true);
        imgKindom[_index].SetBool("imgkindomunlock", true);
        imgUnlock[_index].SetBool("imgunlock", true);
        imgHide2[_index].SetBool("imghide2unlock", true);
    }
}