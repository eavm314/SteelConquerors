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
        troops = deck.TroopsPrefabs.Select( prefab => prefab.GetComponent<Character>() ).ToList();
    }

    private void OnMouseDown()
    {
        if (deck.TroopSelected == -1)
            return;

        if (troops[deck.TroopSelected].price > deck.Gold)
        {
            deck.NotEnoughGoldAlert();
            return;
        }

        GameObject newTroop = Instantiate(troops[deck.TroopSelected].gameObject);
        newTroop.transform.position = transform.position + Vector3.back;

        deck.Gold -= newTroop.GetComponent<Character>().price;

        deck.TroopSelected = -1;
        
    }
}
