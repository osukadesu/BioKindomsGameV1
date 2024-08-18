using System;
using UnityEngine;
public class SetQuestSystem : MonoBehaviour
{
    [SerializeField] QuestCaseRandom questCaseRandom;
    [SerializeField] QuestCaseAnimal questCaseAnimal;
    [SerializeField] QuestCaseVegetal questCaseVegetal;
    [SerializeField] QuestCaseFungi questCaseFungi;
    [SerializeField] QuestCaseProtista questCaseProtista;
    [SerializeField] QuestCaseMonera questCaseMonera;
    void Awake()
    {
        questCaseRandom = FindObjectOfType<QuestCaseRandom>();
        questCaseAnimal = FindObjectOfType<QuestCaseAnimal>();
        questCaseVegetal = FindObjectOfType<QuestCaseVegetal>();
        questCaseFungi = FindObjectOfType<QuestCaseFungi>();
        questCaseProtista = FindObjectOfType<QuestCaseProtista>();
        questCaseMonera = FindObjectOfType<QuestCaseMonera>();
    }
    public void SetCase(int _value)
    {
        questCaseRandom.SetRandomCase(_value);
        Action action = _value switch
        {
            0 => () => AnimalQuest(questCaseRandom.SetRandomCase(_value)),
            1 => () => VegetalQuest(questCaseRandom.SetRandomCase(_value)),
            2 => () => FungiQuest(questCaseRandom.SetRandomCase(_value)),
            3 => () => ProtistaQuest(questCaseRandom.SetRandomCase(_value)),
            4 => () => MoneraQuest(questCaseRandom.SetRandomCase(_value)),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
    void AnimalQuest(int _value)
    {
        Action action = _value switch
        {
            0 => () => questCaseAnimal.SetAnimal1(questCaseRandom.SetRandomKing()),
            1 => () => questCaseAnimal.SetAnimal2(questCaseRandom.SetRandomKing()),
            2 => () => questCaseAnimal.SetAnimal3(questCaseRandom.SetRandomKing()),
            3 => () => questCaseAnimal.SetAnimal4(questCaseRandom.SetRandomKing()),
            4 => () => questCaseAnimal.SetAnimal5(questCaseRandom.SetRandomKing()),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
    void VegetalQuest(int _value)
    {
        Action action = _value switch
        {
            5 => () => questCaseVegetal.SetVegetal1(questCaseRandom.SetRandomKing()),
            6 => () => questCaseVegetal.SetVegetal2(questCaseRandom.SetRandomKing()),
            7 => () => questCaseVegetal.SetVegetal3(questCaseRandom.SetRandomKing()),
            8 => () => questCaseVegetal.SetVegetal4(questCaseRandom.SetRandomKing()),
            9 => () => questCaseVegetal.SetVegetal5(questCaseRandom.SetRandomKing()),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
    void FungiQuest(int _value)
    {
        Action action = _value switch
        {
            10 => () => questCaseFungi.SetFungi1(questCaseRandom.SetRandomKing()),
            11 => () => questCaseFungi.SetFungi2(questCaseRandom.SetRandomKing()),
            12 => () => questCaseFungi.SetFungi3(questCaseRandom.SetRandomKing()),
            13 => () => questCaseFungi.SetFungi4(questCaseRandom.SetRandomKing()),
            14 => () => questCaseFungi.SetFungi5(questCaseRandom.SetRandomKing()),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
    void ProtistaQuest(int _value)
    {
        Action action = _value switch
        {
            16 => () => questCaseProtista.SetProtista1(questCaseRandom.SetRandomKing()),
            17 => () => questCaseProtista.SetProtista2(questCaseRandom.SetRandomKing()),
            18 => () => questCaseProtista.SetProtista3(questCaseRandom.SetRandomKing()),
            19 => () => questCaseProtista.SetProtista4(questCaseRandom.SetRandomKing()),
            20 => () => questCaseProtista.SetProtista5(questCaseRandom.SetRandomKing()),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
    void MoneraQuest(int _value)
    {
        Action action = _value switch
        {
            21 => () => questCaseMonera.SetMonera1(questCaseRandom.SetRandomKing()),
            22 => () => questCaseMonera.SetMonera1(questCaseRandom.SetRandomKing()),
            23 => () => questCaseMonera.SetMonera1(questCaseRandom.SetRandomKing()),
            24 => () => questCaseMonera.SetMonera1(questCaseRandom.SetRandomKing()),
            25 => () => questCaseMonera.SetMonera1(questCaseRandom.SetRandomKing()),
            _ => () => Debug.Log("SetCase case default!"),
        };
        action();
    }
}