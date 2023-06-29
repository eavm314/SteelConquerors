using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSingleton
{
    private static DataSingleton instance;

    public bool Victory { get; set; }
    public int Level { get; set; }
                                     
    public static DataSingleton Instance
    {
        get
        {
            if (instance == null)
                instance = new DataSingleton();
            return instance;
        }
    }
}
