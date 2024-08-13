using System;
using UnityEngine;
public class ChanginLevelCollision : MonoBehaviour
{
    [SerializeField] LevelSystemV2 levelSystemV2;
    void Awake()
    {
        levelSystemV2 = FindObjectOfType<LevelSystemV2>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            levelSystemV2.ChangeLevel();
        }
    }
}