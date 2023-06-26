using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMap : MonoBehaviour
{
    [SerializeField] private GameObject gold;
    [SerializeField] private GameObject cell;

    private GameObject[,] cellsMatrix;

    void Start()
    {
        cellsMatrix = new GameObject[5, 9];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 9; j++)
            {
                cellsMatrix[i, j] = Instantiate(cell, transform);
            }
        }

    }

    public void GenerateGold()
    {
        int col = Random.Range(0, 9);
        int row = Random.Range(0, 5);

        GameObject goldCell = Instantiate(gold);

        goldCell.transform.position = cellsMatrix[row, col].transform.position;

    }
}
