using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class Notification : MonoBehaviour
{
    [SerializeField] Text textCount;
    [SerializeField] Image imageRound;
    [SerializeField] Button btnNotification;
    [SerializeField] GameObject notificationContent, notificationPrefab;
    [SerializeField] Transform transformContent;
    int notificationCount;
    bool active;
    void Awake() => btnNotification.onClick.AddListener(ShowNotification);
    void Start()
    {
        active = false;
        SetVariables(false, "");
        notificationContent.SetActive(false);
    }
    void ShowNotification()
    {
        active = !active;
        notificationContent.SetActive(active);
        if (!active)
        {
            notificationCount = 0;
            SetVariables(false, notificationCount.ToString());
            GeneralSingleton.generalSingleton.MouseLock();
        }
    }
    public void SetNotificationsLevel(int _level)
    {
        Action action = _level switch
        {
            3 => () =>
            {
                if (!GeneralSingleton.generalSingleton.wasFirtsTime)
                { AddNotification("Haz desbloqueado tu perfil presiona este botón para ver!", true); }
            }
            ,
            11 => () => SetDoubleNotification(0, "Animal!", "Ahora ve al reino vegetal!"),
            22 => () => SetDoubleNotification(1, "Vegetal!", "Ahora ve al reino Fungi!"),
            33 => () => SetDoubleNotification(2, "Fungi!", "Ahora ve al reino Protista!"),
            44 => () => SetDoubleNotification(3, "Protista!", "Ahora ve al reino Monera!"),
            55 => () => SetDoubleNotification(4, "Monera!", "Haz terminado el juego!"),
            _ => () => Debug.Log("Case Default"),
        };
        action();
    }
    void SetDoubleNotification(int _index, string _kingdom, string _endMessagge)
    {
        if (!GeneralSingleton.generalSingleton.endQuest[_index])
        { DoubleNotifys("Felicidades haz completado el reino " + _kingdom, false, _endMessagge, false); }
    }
    void DoubleNotifys(string _notify1, bool _isBtnNotify1, string _notify2, bool _isBtnNotify2)
    {
        AddNotification(_notify1, _isBtnNotify1);
        StartCoroutine(WaitForNotify(_notify2, _isBtnNotify2));
    }
    IEnumerator WaitForNotify(string _message, bool _isBtnNotify)
    {
        yield return new WaitForSeconds(1f);
        AddNotification(_message, _isBtnNotify);
    }
    public void AddNotification(string message, bool _isBtnNotify)
    {
        GeneralSingleton.generalSingleton.isBtnNotify = _isBtnNotify;
        GeneralSingleton.generalSingleton.MouseUnLock();
        StartCoroutine(WaitForNotification(message));
    }
    IEnumerator WaitForNotification(string message)
    {
        yield return new WaitForSeconds(1f);
        notificationCount++;
        SetVariables(true, notificationCount.ToString());
        AddNotificationToList(message);
    }
    void SetVariables(bool _bool, string _text)
    {
        imageRound.gameObject.SetActive(_bool);
        textCount.text = _text;
    }
    void AddNotificationToList(string message)
    {
        GameObject newNotification = Instantiate(notificationPrefab, transformContent);
        Text textNotification = newNotification.GetComponentInChildren<Text>();
        textNotification.text = message;
    }
}