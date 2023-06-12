using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameMap : MonoBehaviour
{
    readonly int TROOP = 1;
    readonly int GOLD = 2;

    public DeckManager Deck;
    public GameObject GoldObject;

    List<Character> troops;
    int[,] gameMap = new int[5, 9];

    void Start()
    {
        troops = Deck.troops;

        Random rnd = new();
        for (int i = 0; i < 5; i++)
        {
            int col = rnd.Next(9);
            int row = rnd.Next(5);

            gameMap[row, col] = GOLD;

            Vector2 mapPoint = GetPointInMapFromMatrix(row, col);
            GameObject gold = Instantiate(GoldObject);
            gold.transform.position = mapPoint + Vector2.up * 0.5f;
        }


    }

    private void OnMouseDown()
    {
        if (Deck.troopSelected == -1)
            return;

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(r.origin, r.direction);

        if (hit.collider == null)
            return;

        int col = -((int)Mathf.Round(hit.point.x / 1.3f)) + 3;
        int row = ((int)Mathf.Floor(hit.point.y / 1.5f)) + 3;

        if (gameMap[row, col] > 0 )
            return;

        gameMap[row, col] = TROOP;

        Vector2 mapPoint = GetPointInMapFromMatrix(row, col);
        GameObject newTroop = Instantiate(troops[Deck.troopSelected].gameObject);
        newTroop.transform.position = mapPoint;
        Deck.troopSelected = -1;

    }

    private Vector2 GetPointInMapFromMatrix(int row, int col)
    {
        return new((-col + 3) * 1.3f, (row - 3) * 1.5f);
    }
}
