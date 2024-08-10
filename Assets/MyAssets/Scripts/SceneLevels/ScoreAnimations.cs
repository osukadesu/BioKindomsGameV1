using UnityEngine;
public class ScoreAnimations : MonoBehaviour
{
    [SerializeField] Animator scoreValueAnim;
    public void SwitchAnimations(int _index)
    {
        switch (_index)
        {
            case 5:
                scoreValueAnim.SetBool("score5", true);
                scoreValueAnim.SetBool("score4", false);
                scoreValueAnim.SetBool("score3", false);
                scoreValueAnim.SetBool("scorelose", false);
                break;
            case 4:
                scoreValueAnim.SetBool("score5", false);
                scoreValueAnim.SetBool("score4", true);
                scoreValueAnim.SetBool("score3", false);
                scoreValueAnim.SetBool("scorelose", false);
                break;
            case 3:
                scoreValueAnim.SetBool("score5", false);
                scoreValueAnim.SetBool("score4", false);
                scoreValueAnim.SetBool("score3", true);
                scoreValueAnim.SetBool("scorelose", false);
                break;
            case 2:
                scoreValueAnim.SetBool("score5", false);
                scoreValueAnim.SetBool("score4", false);
                scoreValueAnim.SetBool("score3", false);
                scoreValueAnim.SetBool("scorelose", true);
                break;
            case 1:
                scoreValueAnim.SetBool("score5", false);
                scoreValueAnim.SetBool("score4", false);
                scoreValueAnim.SetBool("score3", false);
                scoreValueAnim.SetBool("scorelose", true);
                break;
            case 0:
                scoreValueAnim.SetBool("score5", false);
                scoreValueAnim.SetBool("score4", false);
                scoreValueAnim.SetBool("score3", false);
                scoreValueAnim.SetBool("scorelose", true);
                break;
        }
    }
}