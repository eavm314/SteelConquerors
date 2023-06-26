using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGenerator : MonoBehaviour
{
    private float[] posY = { 1.2f, -0.4f, -2.0f, -3.6f, -5.2f };
    private float posX = -12;

    [SerializeField] private List<GameObject> robotsPrefabs;

    private int numRobots = 10;
    private int timeToNext = 10;

    private int currentTime = 0;
    private int currentRobots = 0;

    private void Start()
    {
        enabled = false;
        timeToNext *= 50;
    }

    private void FixedUpdate()
    {
        if (currentRobots >= numRobots)
            enabled = false;

        currentTime++;
        if (currentTime < timeToNext)
            return;

        int robot = Random.Range(0, 2);
        int pos = Random.Range(0, 5);

        Instantiate(robotsPrefabs[robot], new(posX, posY[pos]), Quaternion.identity);
        currentRobots++;
        currentTime = 0;
    }
}
