using System.Collections;
using UnityEngine;
public class OpenDoorMessage : MonoBehaviour
{
    [SerializeField] TextGralController textInfo;
    public void SetMessage()
    {
        StartCoroutine(IETextShow("Aun no has desbloqueado este nivel!"));
    }
    IEnumerator IETextShow(string text)
    {
        textInfo.ShowText(text);
        yield return new WaitForSeconds(4f);
        textInfo.HideText();
    }
}