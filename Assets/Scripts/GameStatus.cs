using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//遊戲狀態
public class GameStatus
{
    private static Status _gameStatus = Status.STOP;
    public enum Status
    {
        RUNNING,
        STOP
    }

    public static Status gameStatus
    {
        get => _gameStatus;
        set
        {
            _gameStatus = value;
        }
    }
}
