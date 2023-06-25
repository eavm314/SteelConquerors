using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int healthPoints;
    private GameManager gameManager;

    void Start()
    {
        healthPoints = 1000;
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Robot robot = collision.GetComponent<Robot>();
        robot.Explode();

        healthPoints -= robot.healthPoints;

        if (healthPoints <= 0)
        {
            gameManager.GameOver();
        }
    }
}
