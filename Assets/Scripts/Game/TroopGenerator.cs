using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TroopGenerator : MonoBehaviour
{
    private DeckManager deck;

    private List<Character> troops;

    void Start()
    {
        deck = FindObjectOfType<DeckManager>();
        troops = deck.troopsPrefabs.Select( prefab => prefab.GetComponent<Character>() ).ToList();
    }

    private void OnMouseDown()
    {
        if (deck.troopSelected == -1)
            return;

        if (troops[deck.troopSelected].price > deck.gold)
            return;

        GameObject newTroop = Instantiate(troops[deck.troopSelected].gameObject);
        newTroop.transform.position = transform.position;

        deck.gold -= newTroop.GetComponent<Character>().price;
        deck.UpdateGold();

        deck.troopSelected = -1;
        
    }
}
