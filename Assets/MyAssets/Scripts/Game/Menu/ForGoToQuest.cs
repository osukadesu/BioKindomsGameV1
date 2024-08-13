using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ForGoToQuest : MonoBehaviour
{
    [SerializeField] QuestLevel questLevel;
    [SerializeField] LevelSystemV2 LevelSystemV2;
    void Awake()
    {
        questLevel = FindObjectOfType<QuestLevel>();
        LevelSystemV2 = FindObjectOfType<LevelSystemV2>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GoToQuest(LevelSystemV2.CurrentLevel);
        }
    }
    void GoToQuest(int _level)
    {
        Action action = _level switch
        {
            11 => () => { questLevel.CaseValue = -1; }
            ,
            _ => throw new NotImplementedException(),
        };
        action();
        questLevel.ChangeQuestLevel();
        StartCoroutine(ChageScene());
    }
    IEnumerator ChageScene()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }
}