using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCell : MonoBehaviour
{
    private DeckManager deck;
    [SerializeField] private GameObject merchantPrefab;

    private int totalGold = 50;

    void Start()
    {
        deck = FindObjectOfType<DeckManager>();
    }

    public void CollectGold()
    {
        deck.gold+=10;
        deck.UpdateGold();

        totalGold -= 10;
        if (totalGold <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        if (deck.troopSelected != 0)
            return;

        if (deck.gold < merchantPrefab.GetComponent<Character>().price)
            return;

        GameObject newTroop = Instantiate(merchantPrefab);
        newTroop.transform.position = transform.position;

        deck.gold -= merchantPrefab.GetComponent<Character>().price;
        deck.UpdateGold();

        deck.troopSelected = -1;
    }
}
