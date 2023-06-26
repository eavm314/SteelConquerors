using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private DeckManager deck;
    private SellTroopButton sellTroopButton;
    private RobotGenerator robotGenerator;
    private GoldGenerator goldGenerator;

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
        deck.CreateCards();
        robotGenerator.enabled = true;
    }

    public void GameOver()
    {
        deck.gameObject.SetActive(false);
        sellTroopButton.gameObject.SetActive(false);
        robotGenerator.enabled = false;
        goldGenerator.enabled = false;

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
