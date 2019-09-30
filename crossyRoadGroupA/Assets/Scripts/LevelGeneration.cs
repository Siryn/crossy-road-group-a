using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    private GameObject player;
    public GameObject[] rowObject = new GameObject[5];

    public int tileCells = 15;
    public int tileRows = 10;
    public float tileDensity = 0.75f;
    private int randomRow = 0;

    private Vector3 posStart = new Vector3(0, 0, 0);

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        posStart = new Vector3(-1, 0, ((tileCells - 1) / -2));

        InitialTerrain();
    }

    private void InitialTerrain()
    {
        for (int i = 0; i < tileRows; i++)
        {
            RandomizeRow();

            if (i < 3)
            {
                SpawnRow(0, i);
            }
            else
            {
                SpawnRow(randomRow, i);
            }
        }
    }

    private void SpawnRow(int rowType, int currentRow)
    {
        for (int i = 0; i < tileCells; i++)
        {
            GameObject.Instantiate(rowObject[rowType], (posStart + new Vector3((currentRow), 0, i)), Quaternion.identity);
        }
    }

    private void RandomizeRow()
    {
        if (Random.value < tileDensity)
        {
            randomRow = Random.Range(0, rowObject.Length);
        }
    }
}