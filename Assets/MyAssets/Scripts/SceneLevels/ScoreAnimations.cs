using UnityEngine;
public class ScoreAnimations : MonoBehaviour
{
    [SerializeField] Animator scoreValueAnim;
    public void SwitchAnimations(int _index)
    {
        string[] stringAnim = { "score5", "score4", "score3", "scorelose" };
        foreach (var _string in stringAnim)
        {
            scoreValueAnim.SetBool(_string, false);
        }
        if (_index >= 0 && _index <= 2)
        {
            scoreValueAnim.SetBool("scorelose", true);
        }
        else if (_index >= 3 && _index < stringAnim.Length)
        {
            scoreValueAnim.SetBool(stringAnim[stringAnim.Length - _index - 1], true);
        }
    }
}