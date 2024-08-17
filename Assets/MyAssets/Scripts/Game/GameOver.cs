using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    [SerializeField] AlertModalManager alertModalManager;
    void Awake()
    {
        alertModalManager = FindObjectOfType<AlertModalManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            alertModalManager.AlertInfo("Haz perdido vuelve a internarlo.");
            StartCoroutine(IEChangeScene());
        }
    }
    IEnumerator IEChangeScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}