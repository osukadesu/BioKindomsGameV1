using UnityEngine;
public class ExitQuest : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] QuestGameObjects questGameObjects;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystem>();
        questGameObjects = FindObjectOfType<QuestGameObjects>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //GeneralSingleton.generalSingleton.endQuest[GeneralSingleton.generalSingleton.CaseValue] = true;
            questGameObjects.DestroyAndChangeLevel(levelSystemV2.CurrentLevel);
        }
    }
}