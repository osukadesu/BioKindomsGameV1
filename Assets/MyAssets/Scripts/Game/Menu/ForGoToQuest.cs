using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] LevelSystemV2 levelSystemV2;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
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
        yield return new WaitForSeconds(.6f);
        levelSystemV2.ChangeLevel();
        SceneManager.LoadScene(5);
    }
}