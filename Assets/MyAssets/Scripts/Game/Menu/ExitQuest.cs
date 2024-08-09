using UnityEngine;
public class ExitQuest : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] ShowLevelCaseV2 showLevelCaseV2;
    [SerializeField] QuestLevel questLevel;
    [SerializeField] GameObject[] changeLevel;
    private void Start()
    {
        changeLevel[0].SetActive(false);
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
        switch (_value)
        {
            case 11:
                Destroy(showLevelCaseV2.questKing[0], .2f);
                changeLevel[0].SetActive(true);
                break;
        }
    }
}