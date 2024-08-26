using System;
using UnityEngine;
public class PlayerPosition : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Transform[] targetPlayerPosition;
    void Awake() => playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    void SetPlayerPosition(int _index) => playerMove.transform.position = targetPlayerPosition[_index].position;
    public void SetPlayerPositionWithConditions(int _level)
    {
        Action action = _level switch
        {
            1 or 2 or 4 or 6 or 8 or 10 or 13 or 15 or 17 or 19 or 21 or 24 or 26 or 28 or 32 or 35 or 37 or 39 or 41 or 43 or 46 or
            48 or 50 or 52 or 54
            => () => SetPlayerPosition(0),
            3 or 5 or 7 or 9 => () => SetPlayerPosition(1),
            11 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest[0] ? 0 : 1),
            12 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex] ? 1 : 0),
            14 or 16 or 18 or 20 => () =>
                SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 4 || GeneralSingleton.generalSingleton._kingdomIndex > 4 ? 2 : 0),
            22 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest[1] ? 0 : 2),
            23 or 25 or 27 or 29 or 31 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 4 || GeneralSingleton.generalSingleton._kingdomIndex > 4 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 9 || GeneralSingleton.generalSingleton._kingdomIndex > 9 ? 3 : 0),
            33 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest[2] ? 0 : 3),
            34 or 36 or 38 or 40 or 42 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 4 || GeneralSingleton.generalSingleton._kingdomIndex > 4 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 9 || GeneralSingleton.generalSingleton._kingdomIndex > 9 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 14 || GeneralSingleton.generalSingleton._kingdomIndex > 14 ? 4 : 0),
            44 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest[3] ? 0 : 4),
            45 or 47 or 49 or 51 or 53 or 56 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex < 5 ? 1 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 4 || GeneralSingleton.generalSingleton._kingdomIndex > 4 ? 2 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 9 || GeneralSingleton.generalSingleton._kingdomIndex > 9 ? 3 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 14 || GeneralSingleton.generalSingleton._kingdomIndex > 14 ? 4 :
                GeneralSingleton.generalSingleton.iscloseInfo[GeneralSingleton.generalSingleton._kingdomIndex]
                && GeneralSingleton.generalSingleton._kingdomIndex > 19 || GeneralSingleton.generalSingleton._kingdomIndex > 19 ? 5 : 0),
            55 => () => SetPlayerPosition(GeneralSingleton.generalSingleton.endQuest[4] ? 0 : 5),
            _ => () => Debug.Log("Case default!"),
        };
        action();
    }
}