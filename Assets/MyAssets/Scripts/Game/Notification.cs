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
    void Update()
    {
        //Delete This.
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddNotification("Felicidades haz terminado el reino animal!");
        }
    }
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
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
        }
    }
    public void AddNotification(string message)
    {
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