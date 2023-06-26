using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldGenerator : MonoBehaviour
{
    private GameMap map;
    private int timeToNext = 10;

    private int currentTime = 0;

    private void Start()
    {
        map = FindObjectOfType<GameMap>();

        timeToNext *= 50;
    }

    private void FixedUpdate()
    {
        currentTime++;
        if (currentTime < timeToNext)
            return;

        map.GenerateGold();
        currentTime = 0;

    }
}
