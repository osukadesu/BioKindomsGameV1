using UnityEngine;
public class ChanginLevelCollision : MonoBehaviour
{
    [SerializeField] LevelSystem levelSystemV2;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystem>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelSystemV2.ChangeLevel();
        }
    }
}