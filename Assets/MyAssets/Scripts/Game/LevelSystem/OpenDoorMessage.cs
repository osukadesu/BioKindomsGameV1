using System;
using System.Collections;
using UnityEngine;
public class OpenDoorMessage : MonoBehaviour
{
    [SerializeField] Animator[] _unlockDoors;
    [SerializeField] TextGralController textInfo;
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            UnlockDoors(i, "unlockDoor", false);
        }
    }
    public void SetMessage(int _case, float _time)
    {
        StartCoroutine(IETextShow("Aun no has desbloqueado este nivel!", _case, _time));
    }
    IEnumerator IETextShow(string text, int _case, float _time)
    {
        yield return new WaitForSeconds(_time);
        Action action = _case switch
        {
            0 => () => textInfo.ShowText(text),
            1 => () => textInfo.HideText(),
            _ => () => Debug.Log("Default case!"),
        };
        action();
    }
    public void UnlockDoors(int _index, string _name, bool _bool)
    {
        _unlockDoors[_index].SetBool(_name, _bool);
    }
}