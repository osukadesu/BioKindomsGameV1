using System;
using UnityEngine;
public class QuestGameObjects : MonoBehaviour
{
    [SerializeField] protected internal GameObject[] questKing, exitQuest, changeLevel;
    void Start()
    {
        for (int i = 0; i < changeLevel.Length; i++)
        { changeLevel[i].SetActive(false); }
    }
    public void DestroyAndChangeLevel(int _level)
    {
        Action action = _level switch
        {
            11 => () => SetDestroyAndChangeLevel(0),
            22 => () => SetDestroyAndChangeLevel(1),
            33 => () => SetDestroyAndChangeLevel(2),
            44 => () => SetDestroyAndChangeLevel(3),
            55 => () => SetDestroyAndChangeLevel(4),
            _ => () => Debug.Log("DestroyingObjetc case default!"),
        };
        action();
    }
    public void SetDestroyAndChangeLevel(int _index)
    {
        Destroy(questKing[_index], .2f);
        changeLevel[_index].SetActive(true);
    }
    public void DestroyObjects(int _level)
    {
        Action action = _level switch
        {
            12 or 14 or 16 or 18 or 20 or 22 => () => DestroyingObjects(0),
            23 or 25 or 27 or 29 or 31 or 33 => () => DestroyingObjects(1),
            34 or 36 or 38 or 40 or 42 or 44 => () => DestroyingObjects(2),
            45 or 47 or 49 or 51 or 53 or 55 => () => DestroyingObjects(3),
            56 => () => DestroyingObjects(4),
            _ => () => Debug.Log("Case default"),
        };
        action();
    }
    public void DestroyingObjects(int _index)
    {
        Destroy(questKing[_index], .2f);
        Destroy(exitQuest[_index], .2f);
        Destroy(changeLevel[_index], .2f);
    }
    public void QuestExitKingInLevel(int _level)
    {
        Action action = _level switch
        {
            >= 1 and <= 10 => () => SwitchQuestExitKing(0),
            11 => () => SwitchQuestExitKing(1),
            >= 12 and <= 21 => () => SwitchQuestExitKing(2),
            22 => () => SwitchQuestExitKing(3),
            >= 23 and <= 32 => () => SwitchQuestExitKing(4),
            33 => () => SwitchQuestExitKing(5),
            >= 34 and <= 43 => () => SwitchQuestExitKing(6),
            44 => () => SwitchQuestExitKing(7),
            >= 45 and <= 54 => () => SwitchQuestExitKing(8),
            55 => () => SwitchQuestExitKing(9),
            _ => () => Debug.Log("Case default"),
        };
        action();
    }
    void SwitchQuestExitKing(int _value)
    {
        Action action = _value switch
        {
            0 => () =>
            {
                for (int i = 0; i < 5; i++) { SetQuestExitKing(i, false); }
            }
            ,
            1 => () =>
            {
                SetQuestExitKing(0, true);
                for (int i = 1; i < 5; i++)
                {
                    SetQuestExitKing(i, false);

                }
            }
            ,
            2 => () =>
            {
                for (int i = 1; i < 5; i++)
                {
                    SetQuestExitKing(i, false);
                }
            }
            ,
            3 => () =>
            {
                SetQuestExitKing(1, true);
                for (int i = 2; i < 5; i++)
                {
                    SetQuestExitKing(i, false);
                }
            }
            ,
            4 => () =>
            {
                for (int i = 2; i < 5; i++)
                {
                    SetQuestExitKing(i, false);
                }
            }
            ,
            5 => () =>
            {
                SetQuestExitKing(2, true);
                for (int i = 3; i < 5; i++)
                {
                    SetQuestExitKing(i, false);
                }
            }
            ,
            6 => () =>
            {
                for (int i = 3; i < 5; i++)
                {
                    SetQuestExitKing(i, false);
                }
            }
            ,
            7 => () =>
            {
                SetQuestExitKing(3, true);
                SetQuestExitKing(4, false);
            }
            ,
            8 => () => { SetQuestExitKing(4, false); }
            ,
            9 => () => { SetQuestExitKing(4, true); }
            ,
            _ => () => Debug.Log("Current Level in default"),
        };
        action();
    }
    void SetQuestExitKing(int _index, bool _bool)
    {
        questKing[_index].SetActive(_bool);
        exitQuest[_index].SetActive(GeneralSingleton.generalSingleton.endQuest[_index]);
    }
}