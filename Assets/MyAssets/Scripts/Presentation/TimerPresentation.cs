using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimerPresentation : MonoBehaviour
{
    void Start()
    {
        Screen.SetResolution(1920, 1080, true);
    }
    void Update()
    {
        StartCoroutine(MyTimer());
    }
    IEnumerator MyTimer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2); //Cambiar a Auth.
    }
}