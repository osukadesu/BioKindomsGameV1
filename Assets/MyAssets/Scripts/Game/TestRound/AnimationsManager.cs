using UnityEngine;
public class AnimationsManager : MonoBehaviour
{
    [SerializeField] Animator[] cardSelects;
    [SerializeField] Animator containerCardAnim, timerAnim;
    [SerializeField] TestRoundSystem testRoundSystem;
    [SerializeField] protected internal bool[] btnPressed = { false, false, false };
    void Awake()
    {
        testRoundSystem = FindObjectOfType<TestRoundSystem>();
    }
    void Start()
    {
        BtnLogicFalse();
    }
    protected internal void BtnLogicFalse()
    {
        AnimationButtons("cardSelect1Move", false);
        AnimationButtons("cardSelect2Move", false);
        AnimationButtons("cardSelect3Move", false);
        for (int i = 0; i < btnPressed.Length; i++)
        {
            btnPressed[i] = false;
        }
        containerCardAnim.SetBool("containerCardHide", false);
    }
    protected internal void SetAnimations(int _index, string _nameAnim)
    {
        btnPressed[_index] = true;
        testRoundSystem.IdBtnSelect = _index;
        AnimationButtons(_nameAnim, true);
        containerCardAnim.SetBool("containerCardHide", true);
    }
    protected internal void AnimationButtons(string _nameAnim, bool _boolAnim)
    {
        for (int i = 0; i < cardSelects.Length; i++)
        {
            cardSelects[i].SetBool(_nameAnim, _boolAnim);
        }
    }
    protected internal void SetTimerAnimation(bool _bool)
    {
        timerAnim.SetBool("timerLoadChange", _bool);
    }
}