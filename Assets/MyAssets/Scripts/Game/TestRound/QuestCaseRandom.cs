using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class QuestCaseRandom : MonoBehaviour
{
    [SerializeField] int random, randomKing;
    public int MyRandom { get => random; set => random = value; }
    public int SetRandomCase(int _value)
    {
        Action action = _value switch
        {
            0 => () => random = Random.Range(0, 5),
            1 => () => random = Random.Range(5, 10),
            2 => () => random = Random.Range(10, 15),
            3 => () => random = Random.Range(15, 20),
            4 => () => random = Random.Range(20, 25),
            _ => () => Debug.Log("SetRandomCase case default!"),
        };
        action();
        return random;
    }
    public int SetRandomKing()
    {
        Debug.Log("SetRandomKing value: " + randomKing);
        return randomKing = Random.Range(0, 3);
    }
}