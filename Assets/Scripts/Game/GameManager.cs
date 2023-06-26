using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DeckManager deck;
    private RobotGenerator robotGenerator;
    private GoldGenerator goldGenerator;

    private int timeToStart = 5;
    private void Start()
    {
        deck = FindObjectOfType<DeckManager>();
        robotGenerator = GetComponent<RobotGenerator>();
        goldGenerator = GetComponent<GoldGenerator>();

        Invoke(nameof(StartGame), timeToStart);
    }

    private void StartGame()
    {
        deck.CreateCards();
        robotGenerator.enabled = true;
    }

    public void GameOver()
    {
        deck.gameObject.SetActive(false);
        robotGenerator.enabled = false;

        Robot[] robots = FindObjectsOfType<Robot>();
        Character[] characters = FindObjectsOfType<Character>();

        foreach (Character c in characters)
        {
            c.Die();
        }

        foreach (Robot r in robots)
        {
            r.Win();
        }
    }

}
