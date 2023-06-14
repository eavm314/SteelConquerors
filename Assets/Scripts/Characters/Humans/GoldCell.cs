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

        GameObject merchant = Instantiate(merchantPrefab);
        merchant.transform.position = transform.position;

        deck.troopSelected = -1;
    }
}
