using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChanginLevelCollision : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystem;
    [SerializeField] QuestLevel questLevel;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
        questLevel = FindObjectOfType<QuestLevel>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoToWhat(levelSystem.CurrentLevel);
        }
    }
    void GoToWhat(int _level)
    {
        switch (_level)
        {
            case 2:
                //24
                questLevel.ChangeLevel();
                StartCoroutine(ChageScene());
                break;
            default:
                levelSystem.ChangeLevel();
                break;
        }
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene(4);
    }
}