using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RobotGenerator : MonoBehaviour
{
    private float[] posY = { 1.2f, -0.4f, -2.0f, -3.6f, -5.2f };
    private float posX = -12;

    [SerializeField] private List<GameObject> robotsPrefabs;
    private int numRobots;

    private int timeToNext;

    private int currentTime = 0;

    [SerializeField] private TextMeshProUGUI robotsText;

    [SerializeField] private int _currentRobots;
    public int CurrentRobots
    {
        get { return _currentRobots; }
        set
        {
            _currentRobots = value;
            robotsText.text = _currentRobots.ToString();
        }
    }


    private void Start()
    {
        CurrentRobots = DataSingleton.Instance.LevelData.RobotsAmount;
        timeToNext = DataSingleton.Instance.LevelData.RobotsTime;
        enabled = false;
        timeToNext *= 50;
        numRobots = robotsPrefabs.Count;
    }

    private void FixedUpdate()
    {
        if (CurrentRobots == 0)
        {
            enabled = false;
            FindObjectOfType<GameManager>().CheckVictory();
            return;
        }

        currentTime++;
        if (currentTime < timeToNext)
            return;

        int robot = Random.Range(0, numRobots);
        int pos = Random.Range(0, 5);

        Instantiate(robotsPrefabs[robot], new(posX, posY[pos]), Quaternion.identity);
        
        CurrentRobots --;
        currentTime = 0;
    }


}
