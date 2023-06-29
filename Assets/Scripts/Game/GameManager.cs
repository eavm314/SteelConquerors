using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private DeckManager deck;
    private SellTroopButton sellTroopButton;
    private RobotGenerator robotGenerator;
    private GoldGenerator goldGenerator;
    [SerializeField] private GameObject robotsCount;
    [SerializeField] private GameObject castleLife;
    [SerializeField] private GameObject counter;

    private void Start()
    {
        Camera.main.eventMask = LayerMask.GetMask("UI", "Humans");

        deck = FindObjectOfType<DeckManager>();
        sellTroopButton = FindObjectOfType<SellTroopButton>();
        sellTroopButton.gameObject.SetActive(false);
        robotGenerator = GetComponent<RobotGenerator>();
        goldGenerator = GetComponent<GoldGenerator>();

        Invoke(nameof(Counter), 0.5f);
    }

    private void Counter()
    {
        Invoke(nameof(StartGame), counter.GetComponent<Counter>().value);
        counter.SetActive(true);
    }

    private void StartGame()
    {
        Destroy(counter);

        deck.gameObject.SetActive(true);
        robotsCount.SetActive(true);
        castleLife.SetActive(true);
        sellTroopButton.gameObject.SetActive(true);
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

        DataSingleton.Instance.Victory = false;
        Invoke(nameof(FinishGame), 5);
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

        DataSingleton.Instance.Victory = true;
        Invoke(nameof(FinishGame), 4);
    }

    public void FinishGame()
    {
        SceneManager.LoadScene(3);
    }
}
