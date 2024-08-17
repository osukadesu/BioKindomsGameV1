using System;
using UnityEngine;
using Random = UnityEngine.Random;
public class QuestCaseRandom : MonoBehaviour
{
    [SerializeField] int random, lastRandom = -1;
    public int _myRandom { get => random; set => random = value; }
    public int SetRandom(int _value)
    {
        Action action = _value switch
        {
            0 => () => random = NotRepiteRandom(0, 5),
            1 => () => random = NotRepiteRandom(5, 10),
            2 => () => random = NotRepiteRandom(10, 15),
            3 => () => random = NotRepiteRandom(15, 20),
            4 => () => random = NotRepiteRandom(20, 25),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
        return random;
    }
    int NotRepiteRandom(int rangeInit, int rangeEnd)
    {
        int newRandom;
        do { newRandom = Random.Range(rangeInit, rangeEnd); }
        while (newRandom == lastRandom);
        lastRandom = newRandom;
        return newRandom;
    }
}