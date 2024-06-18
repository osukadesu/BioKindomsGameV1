using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChanginLevelCollision : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystem;
    [SerializeField] QuestLevel questLevel;
    void Awake()
    {
        levelSystem = FindObjectOfType<LevelSystemV2>();
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
            case 12:
                questLevel.ChangeQuestLevel();
                StartCoroutine(ChageScene());
                levelSystem.ChangeLevel();
                break;
            /*
             case 24:
                questLevel.ChangeQuestLevel();
                StartCoroutine(ChageScene());
                levelSystem.ChangeLevel();
                break;
            */
            default:
                levelSystem.ChangeLevel();
                break;
        }
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(.05f);
        SceneManager.LoadScene(4);
    }
}