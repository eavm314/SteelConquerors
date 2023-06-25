using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DeckManager deck;
    private GameMap map;
    private RobotGenerator robotGenerator;

    [SerializeField] private int timeToStart;
    private void Start()
    {
        deck = FindObjectOfType<DeckManager>();
        map = FindObjectOfType<GameMap>();
        robotGenerator = FindObjectOfType<RobotGenerator>();

        Invoke("StartGame", timeToStart);
    }

    private void StartGame()
    {
        deck.CreateCards();
        map.GenerateGold();
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
