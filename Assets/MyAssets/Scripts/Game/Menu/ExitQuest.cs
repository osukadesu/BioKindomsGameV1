using System;
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
    void Start()
    {
        for (int i = 0; i < questGameObjects.changeLevel.Length; i++)
        { questGameObjects.changeLevel[i].SetActive(false); }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GeneralSingleton.generalSingleton.endQuest = false;
            GeneralSingleton.generalSingleton.wasEndQuest = true;
            SaveAndLoadManager.SaveSingleton(GeneralSingleton.generalSingleton);
            DestroyingObjetc(levelSystemV2.CurrentLevel);
        }
    }
    void DestroyingObjetc(int _value)
    {
        Action action = _value switch
        {
            11 => () =>
            {
                Destroy(questGameObjects.questKing[0], .2f);
                questGameObjects.changeLevel[0].SetActive(true);
            }
            ,
            _ => () => Debug.Log("DestroyingObjetc case default!"),
        };
        action();
    }
}