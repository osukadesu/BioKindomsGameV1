using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class TimerPresentation : MonoBehaviour
{
    void Update()
    {
        StartCoroutine(MyTimer());
    }
    IEnumerator MyTimer()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}