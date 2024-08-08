using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoToQuest();
        }
    }
    void GoToQuest()
    {
        questLevel.ChangeQuestLevel();
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }
}