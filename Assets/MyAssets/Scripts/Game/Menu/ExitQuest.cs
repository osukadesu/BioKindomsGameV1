using System;
using UnityEngine;
public class ExitQuest : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] QuestLevel questLevel;
    void Start()
    {
        for (int i = 0; i < showLevelCaseV2.changeLevel.Length; i++)
        {
            showLevelCaseV2.changeLevel[i].SetActive(false);
        }
    }
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        questLevel = FindObjectOfType<QuestLevel>();
        showLevelCaseV2 = FindObjectOfType<ShowLevelCaseV2>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            questLevel._endQuest = false;
            DestroyingObjetc(levelSystemV2.CurrentLevel);
        }
    }
    void DestroyingObjetc(int _value)
    {
        Action action = _value switch
        {
            11 => () => { Destroy(showLevelCaseV2.questKing[0], .2f); showLevelCaseV2.changeLevel[0].SetActive(true); }
            ,
            _=> () => Debug.Log("Case default!"),
        };
        action();
    }
}