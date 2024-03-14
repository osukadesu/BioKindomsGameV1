using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CloseLicence : MonoBehaviour
{
    [SerializeField] Button btnClose;
    private void Awake()
    {
        btnClose.onClick.AddListener(ClosetThis);
    }
    void ClosetThis()
    {
        Application.Quit();
        SceneManager.LoadScene(1);
    }
}
