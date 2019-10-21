using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    ////////////
    // VARIABLES
    ////////////
    public GameObject[] rowTiles = new GameObject[5];
    public GameObject[] cellProps = new GameObject[9];
    private List<Row> rowSafe = new List<Row>();
    public List<Row> rowList = new List<Row>();
    public int randomTile = 0;
    public int randomGeneration = 0;
    public int offsetSafeX = 0;
    private int offsetStartX = 0;
    private int offsetZ = 0;
    private Vector3 positionSafe = new Vector3(0, 0, 0);
    private Vector3 positionStart = new Vector3(0, 0, 0);
    ////////////

    /////////
    // EVENTS
    /////////
    void Start()
    {
        SetOffset();
        SpawnSafeZone();
        SpawnInitialTerrain();
    }

    void Update()
    {
        foreach (GameObject pad in GameObject.FindGameObjectsWithTag("lilypad"))
        {
            pad.transform.Rotate(0, 30 * Time.deltaTime, 0);
        }
    }
    /////////

    ////////////
    // FUNCTIONS
    ////////////
    private void SetOffset() //Sets safe and starting locations
    {
        if (GlobalVariables.safeRows % 2 != 0)
        {
            offsetSafeX = (GlobalVariables.safeRows - 1) / 2;
        }
        else
        {
            offsetSafeX = GlobalVariables.safeRows / 2;
        }

        if (GlobalVariables.tileCells % 2 != 0)
        {
            offsetZ = (GlobalVariables.tileCells - 1) / 2;
        }
        else
        {
            offsetZ = GlobalVariables.tileCells / 2;
        }

        offsetStartX = -offsetSafeX + GlobalVariables.safeRows;
        positionSafe = new Vector3(-offsetSafeX, -.1f, -offsetZ);
        positionStart = positionSafe + new Vector3(GlobalVariables.safeRows, 0, 0);
        GlobalVariables.currentMaxRow = GlobalVariables.generationThreshold + offsetSafeX;
    }

    private void SpawnSafeZone() //Generates the safe zone rows
    {
        for (int i = 0; i < GlobalVariables.safeRows; i++)
        {
            rowSafe.Add(new Row(rowTiles, cellProps, 0, 0, (positionSafe + new Vector3(i, 0, 0))));
        }
    }

    private void SpawnInitialTerrain() //Generates the initial randomized rows
    {
        for (int i = 0; i < GlobalVariables.tileRows; i++)
        {
            DenseSelection();
            rowList.Add(new Row(rowTiles, cellProps, randomTile, randomGeneration, (positionStart + new Vector3(i, 0, 0))));
        }
    }

    public void AddRow() //Adds a row to the end
    {
        DenseSelection();
        rowList.Add(new Row(rowTiles, cellProps, randomTile, randomGeneration, (positionStart + new Vector3(rowList.Count, 0, 0))));
    }

    public void RemoveSafeZone()
    {
        foreach (Row row in rowSafe)
        {
            for (int i = 0; i < GlobalVariables.safeRows; i++)
            {
                row.DestroyRow(i);
            }
        }
    }

    public void DenseSelection() //Generates the type of row and generation profile to spawn
    {
        if (Random.value < GlobalVariables.rowDensity)
        {
            randomTile = Random.Range(0, rowTiles.Length);
        }

        if (Random.value < GlobalVariables.generationDensity)
        {
            randomGeneration = Random.Range(0, 3);
        }
    }
    ////////////
}