using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCell : MonoBehaviour
{
    private DeckManager deck;
    public GameObject merchantPrefab;

    void Start()
    {
        deck = FindObjectOfType<DeckManager>();
    }

    public void CollectGold()
    {
        deck.gold++;
        deck.UpdateGold();
    }

    private void OnMouseDown()
    {
        if (deck.troopSelected != 0)
            return;

        if (deck.gold < merchantPrefab.GetComponent<Character>().price)
            return;

        deck.CreateTroop(transform.position);
    }
}
