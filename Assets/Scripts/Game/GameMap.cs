using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameMap : MonoBehaviour
{
    public GameObject gold;
    public GameObject cell;

    private GameObject[,] cellsMatrix = new GameObject[5, 9];

    void Start()
    {
        for (int i = 0; i < 5; i++)
        { 
            for(int j = 0; j < 9; j++)
            {
                cellsMatrix[i, j] = Instantiate(cell,transform);
            }
        }

        Invoke("GenerateGold", 1);

    }

    public void GenerateGold()
    {
        for (int i=0; i < 5; i++)
        {
            int col = Random.Range(0,9);
            int row = Random.Range(0,5);

            //print("col: "+ col+" row: "+ row);

            GameObject goldCell = Instantiate(gold);

            goldCell.transform.position = cellsMatrix[row, col].transform.position;
        }
    }
}
