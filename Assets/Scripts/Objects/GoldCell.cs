using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCell : MonoBehaviour
{
    private DeckManager deck;

    private int totalGold = 50;

    void Start()
    {
        deck = FindObjectOfType<DeckManager>();
    }

    public void CollectGold()
    {
        deck.Gold+=10;

        totalGold -= 10;
        if (totalGold <= 0)
        {
            Destroy(gameObject);
        }
    }
}
