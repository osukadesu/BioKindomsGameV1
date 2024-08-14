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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        active = false;
        SetVariables(false, "");
        notificationContent.SetActive(false);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            AddNotification("La tecla P ha sido presionada");
        }
    }
    void ShowNotification()
    {
        active = !active;
        notificationContent.SetActive(active);
    }
    public void AddNotification(string message)
    {
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