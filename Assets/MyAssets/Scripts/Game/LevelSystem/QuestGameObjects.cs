using System;
using UnityEngine;
public class QuestGameObjects : MonoBehaviour
{
    [SerializeField] protected internal GameObject[] questKing, exitQuest, changeLevel;
    public void DestroyingObjects(int _index)
    {
        Destroy(questKing[_index], .2f);
        Destroy(exitQuest[_index], .2f);
        Destroy(changeLevel[_index], .2f);
    }
    public void SwitchQuestExitKing(int _value)
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
                SetQuestExitKing(1, false);
                SetQuestExitKing(2, false);
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
            }
            ,
            2 => () =>
            {
                SetQuestExitKing(1, false);
                SetQuestExitKing(2, false);
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
            }
            ,
            3 => () =>
            {
                SetQuestExitKing(1, true);
                SetQuestExitKing(2, false);
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
            }
            ,
            4 => () =>
            {
                SetQuestExitKing(2, false);
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
            }
            ,
            5 => () =>
            {
                SetQuestExitKing(2, true);
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
            }
            ,
            6 => () =>
            {
                SetQuestExitKing(3, false);
                SetQuestExitKing(4, false);
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
    public void SetQuestExitKing(int _index, bool _bool)
    {
        questKing[_index].SetActive(_bool);
        exitQuest[_index].SetActive(GeneralSingleton.generalSingleton.endQuest);
    }
}
