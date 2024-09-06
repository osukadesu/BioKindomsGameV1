using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Notification : MonoBehaviour
{
    [SerializeField] AlertModalManager alertModalManager;
    [SerializeField] Text textCount;
    [SerializeField] Image imageRound;
    [SerializeField] Button btnNotification;
    [SerializeField] GameObject notificationContent, notificationPrefab;
    [SerializeField] Transform transformContent;
    int notificationCount;
    bool active;
    void Awake()
    {
        alertModalManager = FindObjectOfType<AlertModalManager>();
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
                {
                    StartCoroutine(alertModalManager.GoTos("Haz desbloqueado tu perfil presiona continuar para verlo!"));
                }
            }
            ,
            11 => () => alertModalManager.StartIELevelCaseV2(true, "Felicidades haz completado el reino Animal! \n Ahora ve al reino Vegetal!"),
            22 => () => alertModalManager.StartIELevelCaseV2(true, "Felicidades haz completado el reino Vegetal! \n Ahora ve al reino Fungi!"),
            33 => () => alertModalManager.StartIELevelCaseV2(true, "Felicidades haz completado el reino Fungi! \n Ahora ve al reino Protista!"),
            44 => () => alertModalManager.StartIELevelCaseV2(true, "Felicidades haz completado el reino Protista! \n Ahora ve al reino Monera!"),
            55 => () => alertModalManager.StartIELevelCaseV2(true, "Felicidades haz completado el juego!"),
            _ => () => Debug.Log("Case Default"),
        };
        action();
    }
    void SetDoubleNotification(int _index, string _kingdom, string _endMessagge)
    {
        if (!GeneralSingleton.generalSingleton.endQuest[_index])
        { DoubleNotifys("Felicidades haz completado el reino " + _kingdom, _endMessagge); }
    }
    void DoubleNotifys(string _notify1, string _notify2)
    {
        AddNotification(_notify1);
        StartCoroutine(WaitForNotify(_notify2));
    }
    IEnumerator WaitForNotify(string _message)
    {
        yield return new WaitForSeconds(1f);
        AddNotification(_message);
    }
    public void AddNotification(string message)
    {
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