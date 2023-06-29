using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSingleton
{
    private static DataSingleton instance;
    public static DataSingleton Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new DataSingleton();
                instance.LevelData = LevelData.LevelDefault();
            }
            return instance;
        }
    }

    public bool Victory { get; set; }

    private int _level;
    public int Level
    {
        get { return _level; }
        set
        {
            _level = value;
            LevelData = _level switch
            {
                1 => LevelData.Level1(),
                2 => LevelData.Level2(),
                3 => LevelData.Level3(),
                _ => LevelData.LevelDefault(),
            };
        }
    }

    public LevelData LevelData {get; set;}
}
