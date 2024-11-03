using UnityEngine;
public class ChanginLevelCollision : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystemV2;
    [SerializeField] ItemObject itemObject;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystem>();
        itemObject = FindObjectOfType<ItemObject>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelSystemV2.ChangeLevel();
            itemObject.HideTextV2();
        }
    }
}