using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DeckManager deck;
    private SellTroopButton sellTroopButton;
    private RobotGenerator robotGenerator;
    private GoldGenerator goldGenerator;
    [SerializeField] private GameObject robotsCount;

    private int timeToStart = 5;
    private void Start()
    {
        Camera.main.eventMask = LayerMask.GetMask("UI", "Humans");

        deck = FindObjectOfType<DeckManager>();
        sellTroopButton = FindObjectOfType<SellTroopButton>();
        robotGenerator = GetComponent<RobotGenerator>();
        goldGenerator = GetComponent<GoldGenerator>();

        Invoke(nameof(StartGame), timeToStart);
    }

    private void StartGame()
    {
        robotsCount.SetActive(true);
        deck.CreateCards();
        robotGenerator.enabled = true;
    }

    public void GameOver()
    {
        deck.TroopSelected = -1;
        deck.gameObject.SetActive(false);
        sellTroopButton.gameObject.SetActive(false);
        robotGenerator.enabled = false;
        goldGenerator.enabled = false;

        Robot[] robots = FindObjectsOfType<Robot>();
        Character[] characters = FindObjectsOfType<Character>();

        Array.ForEach(robots, r => r.Win());
        Array.ForEach(characters, c => c.Die());

    }

    public void CheckVictory()
    {
        Robot[] robots = FindObjectsOfType<Robot>();
        if (robots.Length == 0)
        {
            Victory();
            return;
        }

        Invoke(nameof(CheckVictory), 3);
    }

    public void Victory()
    {
        deck.TroopSelected = -1;
        deck.gameObject.SetActive(false);
        sellTroopButton.toggle.isOn = false;
        sellTroopButton.gameObject.SetActive(false);
        goldGenerator.enabled = false;

        Character[] characters = FindObjectsOfType<Character>();
        Array.ForEach(characters, c => c.Win());
    }

}
