using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    [SerializeField] protected internal Text textRoundInfo;
    [SerializeField] protected internal Animator textRoundInfoAnim;
    [SerializeField] Transform textPosition, textPositionInit, textPositionEnd;
    public void ShowText(int posType, string message, string animation)
    {
        StartCoroutine(IEShowText(posType, message, animation));
    }
    public IEnumerator IEShowText(int _posType, string _message, string _animation)
    {
        switch (_posType)
        {
            case 0:
                textPosition.position = textPositionInit.position;
                break;
            case 1:
                textPosition.position = textPositionEnd.position;
                break;
        }
        textRoundInfo.text = _message;
        textRoundInfoAnim.SetBool(_animation, true);
        yield return new WaitForSeconds(2f);
        textRoundInfoAnim.SetBool(_animation, false);
    }
}