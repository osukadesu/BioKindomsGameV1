using System;
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
    public void StartingAT(String anytext2)
    {
        StartCoroutine(AnyText(anytext2));
    }
    IEnumerator AnyText(string anytext)
    {
        ShowText(anytext);
        yield return new WaitForSeconds(4f);
        HideText();
    }
    public void StartingAT2(string anytext22)
    {
        StartCoroutine(AnyText2(anytext22));
    }
    IEnumerator AnyText2(string anytext2)
    {
        ShowText(anytext2);
        yield return new WaitForSeconds(1f);
        HideText();
    }
    public void StartingWTLT(int level2)
    {
        StartCoroutine(WelcomeToLevelText(level2));
    }
    IEnumerator WelcomeToLevelText(int level)
    {
        ShowText("Bienvenido al nivel " + level);
        yield return new WaitForSeconds(1.5f);
        HideText();
    }
    public void StartingIOT()
    {
        StartCoroutine(ItemObjectText());
    }
    IEnumerator ItemObjectText()
    {
        ShowText("Partida guardada!");
        yield return new WaitForSeconds(1.5f);
        HideText();
    }
}