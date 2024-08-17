using System;
using UnityEngine;
public class SetQuestSystem : MonoBehaviour
{
    [SerializeField] QuestCaseRandom questCaseRandom;
    [SerializeField] QuestCaseAnimal questCaseAnimal;
    public void SetCase(int _value)
    {
        questCaseRandom.SetRandom(_value);
        Action action = _value switch
        {
            0 => () => AnimalQuest(questCaseRandom.SetRandom(_value)),
            1 => () => VegetalQuest(questCaseRandom.SetRandom(_value)),
            2 => () => FungiQuest(questCaseRandom.SetRandom(_value)),
            3 => () => ProtistaQuest(questCaseRandom.SetRandom(_value)),
            4 => () => MoneraQuest(questCaseRandom.SetRandom(_value)),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
    void AnimalQuest(int _value)
    {
        Action action = _value switch
        {
            0 => () => questCaseAnimal.SetAnimal1(questCaseRandom._myRandom),
            1 => () => questCaseAnimal.SetAnimal2(questCaseRandom._myRandom),
            2 => () => questCaseAnimal.SetAnimal3(questCaseRandom._myRandom),
            3 => () => questCaseAnimal.SetAnimal4(questCaseRandom._myRandom),
            4 => () => questCaseAnimal.SetAnimal5(questCaseRandom._myRandom),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
    void VegetalQuest(int _value)
    {
        Action action = _value switch
        {
            5 => () => questCaseAnimal.SetAnimal1(questCaseRandom._myRandom),
            6 => () => questCaseAnimal.SetAnimal2(questCaseRandom._myRandom),
            7 => () => questCaseAnimal.SetAnimal3(questCaseRandom._myRandom),
            8 => () => questCaseAnimal.SetAnimal4(questCaseRandom._myRandom),
            9 => () => questCaseAnimal.SetAnimal5(questCaseRandom._myRandom),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
    void FungiQuest(int _value)
    {
        Action action = _value switch
        {
            10 => () => questCaseAnimal.SetAnimal1(questCaseRandom._myRandom),
            11 => () => questCaseAnimal.SetAnimal2(questCaseRandom._myRandom),
            12 => () => questCaseAnimal.SetAnimal3(questCaseRandom._myRandom),
            13 => () => questCaseAnimal.SetAnimal4(questCaseRandom._myRandom),
            14 => () => questCaseAnimal.SetAnimal5(questCaseRandom._myRandom),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
    void ProtistaQuest(int _value)
    {
        Action action = _value switch
        {
            16 => () => questCaseAnimal.SetAnimal1(questCaseRandom._myRandom),
            17 => () => questCaseAnimal.SetAnimal2(questCaseRandom._myRandom),
            18 => () => questCaseAnimal.SetAnimal3(questCaseRandom._myRandom),
            19 => () => questCaseAnimal.SetAnimal4(questCaseRandom._myRandom),
            20 => () => questCaseAnimal.SetAnimal5(questCaseRandom._myRandom),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
    void MoneraQuest(int _value)
    {
        Action action = _value switch
        {
            21 => () => questCaseAnimal.SetAnimal1(questCaseRandom._myRandom),
            22 => () => questCaseAnimal.SetAnimal2(questCaseRandom._myRandom),
            23 => () => questCaseAnimal.SetAnimal3(questCaseRandom._myRandom),
            24 => () => questCaseAnimal.SetAnimal4(questCaseRandom._myRandom),
            25 => () => questCaseAnimal.SetAnimal5(questCaseRandom._myRandom),
            _ => throw new NotImplementedException("Case default!"),
        };
        action();
    }
}