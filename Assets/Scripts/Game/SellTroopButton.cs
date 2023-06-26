using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SellTroopButton : MonoBehaviour
{
    [SerializeField] private DeckManager deck;

    public Toggle toggle;
    private Image background;
    [SerializeField] private Color colorActive;
    [SerializeField] private Color colorNoActive;

    private void Start()
    {
        background = GetComponentInChildren<Image>();

        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(
            (active) =>
            {
                background.color = active? colorActive: colorNoActive;
            });
    }

    public void SellTroop(Character troop)
    {
        deck.Gold += troop.price / 2;

        Destroy(troop.gameObject);
    }

}
