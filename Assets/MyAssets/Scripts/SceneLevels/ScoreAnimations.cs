using System;
using UnityEngine;
public class ScoreAnimations : MonoBehaviour
{
    [SerializeField] Animator scoreValueAnim;
    public void SwitchAnimations(int _index)
    {
        Action action = _index switch
        {
            0 or 1 or 2 => () => ParametersAnim("scorelose"),
            3 => () => ParametersAnim("score3"),
            4 => () => ParametersAnim("score4"),
            5 => () => ParametersAnim("score5"),
            _ => throw new NotImplementedException("Score out!"),
        };
        action();
    }
    void ParametersAnim(string name) => scoreValueAnim.SetBool(name, true);
}