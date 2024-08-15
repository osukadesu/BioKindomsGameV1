using System;
using System.Collections;
using UnityEngine;
public class OpenDoorMessage : MonoBehaviour
{
    [SerializeField] TextGralController textInfo;
    public void SetMessage(int _case, float _time)
    {
        StartCoroutine(IETextShow("Aun no has desbloqueado este nivel!", _case, _time));
    }
    IEnumerator IETextShow(string text, int _case, float _time)
    {
        yield return new WaitForSeconds(_time);
        Action action = _case switch
        {
            0 => () => { textInfo.ShowText(text); }
            ,
            1 => () => { textInfo.HideText(); }
            ,
            _ => throw new NotImplementedException(),
        };
        action();
    }
}