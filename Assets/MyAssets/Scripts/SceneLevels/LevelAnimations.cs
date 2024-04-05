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
    public void LevelFinished(int _index, int _version)
    {
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
    }
}