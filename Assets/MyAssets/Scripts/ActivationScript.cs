using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ActivationScript : MonoBehaviour
{
    [SerializeField] GameObject alertModalError;
    [SerializeField] Button btnClose;
    void Awake()
    {
        btnClose.onClick.AddListener(() => CloseAlert());
        string idDevice = SystemInfo.deviceUniqueIdentifier;
        Debug.Log("Id Dispositivo: " + idDevice);
        string myId = "b3525986066671a758ea97e51ebb24873fc26d0a";
        if (idDevice != myId)
        {
            alertModalError.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
    void Start() => alertModalError.SetActive(false);
    void CloseAlert() => alertModalError.SetActive(false);
}