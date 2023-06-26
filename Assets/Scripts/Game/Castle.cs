using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Castle : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField] private int healthPoints;
    [SerializeField] private TextMeshProUGUI healthText;

    void Start()
    {
        UpdateHealth();

        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Robot robot = collision.GetComponent<Robot>();
        robot.Explode();

        healthPoints -= robot.healthPoints;

        if (healthPoints <= 0)
        {
            healthPoints = 0;
            gameManager.GameOver();
        }

        UpdateHealth();
    }

    public void UpdateHealth()
    {
        healthText.text = healthPoints.ToString();
    }
}
