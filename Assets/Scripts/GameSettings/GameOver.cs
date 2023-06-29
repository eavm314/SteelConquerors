using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI message;
    [SerializeField] private Image background;

    [SerializeField] private Sprite backgroundGameOver;
    [SerializeField] private Sprite backgroundVictory;

    [SerializeField] private string messageGameOver;
    [SerializeField] private string messageVictory;

    private void Awake()
    {
        if (DataSingleton.Instance.Victory)
        {
            message.text = messageVictory;
            background.sprite = backgroundVictory;
        } else
        {
            message.text = messageGameOver;
            background.sprite = backgroundGameOver;
        }
    }
}
