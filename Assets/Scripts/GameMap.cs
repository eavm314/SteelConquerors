using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMap : MonoBehaviour
{
    public DeckManager Deck;

    List<Character> troops;
    bool[,] isTroop = new bool[5, 9];

    void Start()
    {
        troops = Deck.troops;
    }

    private void OnMouseDown()
    {
        if (Deck.troopSelected == -1) 
            return;

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);
        
        if (hit.collider == null) 
            return;

        int newX = ((int)Mathf.Round(hit.point.x / 1.3f));
        int newY = ((int)Mathf.Floor(hit.point.y / 1.5f));

        Debug.Log("x: " + (-newX + 3) + " y: " + (newY + 3));

        if (isTroop[newY + 3, -newX + 3]) 
            return;

        Vector2 landingPoint = new(newX * 1.3f, newY * 1.5f);
        GameObject newTroop = Instantiate(troops[Deck.troopSelected].gameObject);
        newTroop.transform.position = landingPoint;
        Deck.troopSelected = -1;
        isTroop[newY + 3, -newX + 3] = true;



    }
}
