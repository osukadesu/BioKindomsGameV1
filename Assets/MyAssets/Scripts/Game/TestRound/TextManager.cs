using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour
{
    [SerializeField] protected internal Text textRoundInfo;
    [SerializeField] protected internal Animator textRoundInfoAnim;
    protected internal void ShowText(string message, string animation)
    {
        StartCoroutine(IEShowText(message, animation));
    }
    protected internal IEnumerator IEShowText(string message, string animation)
    {
        textRoundInfo.text = message;
        textRoundInfoAnim.SetBool(animation, true);
        yield return new WaitForSeconds(2f);
        textRoundInfoAnim.SetBool(animation, false);
    }
}