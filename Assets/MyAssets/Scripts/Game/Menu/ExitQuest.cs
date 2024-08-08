using UnityEngine;
public class ExitQuest : MonoBehaviour
{
    [SerializeField] GameObject[] questKing, changeLevel;
    [SerializeField] LevelSystemV2 levelSystemV2;
    [SerializeField] QuestLevel questLevel;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
        questLevel = FindObjectOfType<QuestLevel>();
        changeLevel[0].SetActive(false);
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
                Destroy(questKing[0], .4f);
                changeLevel[0].SetActive(true);
                break;
        }
    }
}