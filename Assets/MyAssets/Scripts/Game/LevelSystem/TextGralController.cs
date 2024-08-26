using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class TextGralController : MonoBehaviour
{
    [SerializeField] Animator txtAnim;
    [SerializeField] Text textGral;
    public void ShowText(string message)
    {
        textGral.text = message;
        txtAnim.SetBool("txtinfogral", true);
    }
    public void HideText()
    {
        textGral.text = "";
        txtAnim.SetBool("txtinfogral", false);
    }
    public void StartingAT2(string anytext22) => StartCoroutine(AnyText2(anytext22));
    IEnumerator AnyText2(string anytext2)
    {
        ShowText(anytext2);
        yield return new WaitForSeconds(1f);
        HideText();
    }
}