using System;
using UnityEngine;
public class PlayerPosition : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Transform[] targetPlayerPosition;
    void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    public void SetPlayerPositionWithConditionsx(int _type)
    {
        Action action = _type switch
        {
            0 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 : 0);
            }
            ,
            1 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 : 0);
            }
            ,
            2 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 : 0);
            }
            ,
            3 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 20 ? 5 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 20 ? 4 : 0);
            }
            ,
            4 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 20 ? 5 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 20 ? 4 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 25 ? 6 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 25 ? 5 : 0);
            }
            ,
            _ => () => Debug.Log("Case default!"),
        };
        action();
    }
    public void SetPlayerPosition(int _index)
    {
        playerMove.transform.position = targetPlayerPosition[_index].position;
    }

    public void SetPlayerPositionWithConditionsV2(int _type)
    {
        Action action = _type switch
        {
            1 or 2 or 4 or 6 or 8 or 10 or 13 or 15 or 17 or 19 or 21 or 24
            => () => SetPlayerPosition(0),
            3 or 5 or 7 or 9 => () => SetPlayerPosition(1),
            11 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest ? 0 : 1),
            12 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 1 : 0),
            14 or 16 or 18 or 20 => () =>
            {
                SetPlayerPosition(!GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 0 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 : 1);
            }
            ,
            22 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest ? 0 : 3),
            23 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 3 : 0),
            25 => () => { }
            ,
            28 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 : 0);
            }
            ,
            29 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 : 0);
            }
            ,
            30 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 20 ? 5 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 20 ? 4 : 0);
            }
            ,
            31 => () =>
            {
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 5 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 10 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 10 ? 2 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 15 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 15 ? 3 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 20 ? 5 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 20 ? 4 :
                    GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex >= 25 ? 6 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 25 ? 5 : 0);
            }
            ,
            _ => () => Debug.Log("Case default!"),
        };
        action();
    }


}