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
    void Awake()
    {
        btnNotification.onClick.AddListener(ShowNotification);
    }
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
            11 => () =>
            {
                if (!GeneralSingleton.generalSingleton.endQuest)
                { DoubleNotifys("Felicidades haz completado el reino Animal!", false, "Ahora ve al reino vegetal!", false); }
            }
            ,
            22 => () =>
            {
                if (!GeneralSingleton.generalSingleton.endQuest)
                { DoubleNotifys("Felicidades haz completado el reino Vegetal!", false, "Ahora ve al reino Fungi!", false); }
            }
            ,
            33 => () =>
            {
                if (!GeneralSingleton.generalSingleton.endQuest)
                { DoubleNotifys("Felicidades haz completado el reino Fungi!", false, "Ahora ve al reino Protista!", false); }
            }
            ,
            44 => () =>
            {
                if (!GeneralSingleton.generalSingleton.endQuest)
                { DoubleNotifys("Felicidades haz completado el reino Protista!", false, "Ahora ve al reino Monera!", false); }
            }
            ,
            55 => () =>
            {
                if (!GeneralSingleton.generalSingleton.endQuest)
                { DoubleNotifys("Felicidades haz completado el reino Monera!", false, "Haz terminado el juego!", false); }
            }
            ,
            _ => () => Debug.Log("Case Default"),
        };
        action();
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