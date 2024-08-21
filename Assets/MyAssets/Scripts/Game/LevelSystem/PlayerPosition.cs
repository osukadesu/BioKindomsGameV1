using System;
using UnityEngine;
public class PlayerPosition : MonoBehaviour
{
    [SerializeField] PlayerMove playerMove;
    [SerializeField] Transform[] targetPlayerPosition;
    private void Awake()
    {
        playerMove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
    }
    public void SetPlayerPositionWithConditions(int _type)
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
}