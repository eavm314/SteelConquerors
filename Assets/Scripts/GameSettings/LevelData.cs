using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData
{
    private LevelData() { }

    public int CastleLife { get; set; }
    public int RobotsAmount { get; set; }
    public int RobotsTime { get; set; }

    public static LevelData Level1()
    {
        LevelData data = new()
        {
            CastleLife = 1000,
            RobotsAmount = 5,
            RobotsTime = 10
        };
        return data;
    }

    public static LevelData Level2()
    {
        LevelData data = new()
        {
            CastleLife = 100,
            RobotsAmount = 10,
            RobotsTime = 10
        };
        return data;
    }

    public static LevelData Level3()
    {
        LevelData data = new()
        {
            CastleLife = 10,
            RobotsAmount = 20,
            RobotsTime = 5
        };
        return data;
    }

    public static LevelData LevelDefault()
    {
        LevelData data = new()
        {
            CastleLife = 9999,
            RobotsAmount = 9999,
            RobotsTime = 1
        };
        return data;
    }
}
