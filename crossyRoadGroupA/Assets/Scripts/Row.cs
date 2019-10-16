using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row
{
    ////////////
    // VARIABLES
    ////////////
    public GameObject[] rowTiles = new GameObject[5];
    private List<GameObject> instancedCell = new List<GameObject>();
    ////////////

    /////////////
    // Properties
    /////////////
    public int rowType { get; set; }
    public int genType { get; set; }
    public Vector3 positionRow { get; set; }
    /////////////

    ///////////////
    // CONSTRUCTORS
    ///////////////
    public Row(GameObject[] tiles, int row, int gen, Vector3 position)
    {
        rowTiles = tiles;
        rowType = row;
        genType = gen;
        positionRow = position;

        SpawnRow(rowType, genType, positionRow);
    }
    ///////////////

    //////////
    // METHODS
    //////////
    public void SpawnRow(int row, int gen, Vector3 position) //Adds the designated row
    {
        for (int i = 0; i < GlobalVariables.tileCells; i++)
        {
            instancedCell.Add(GameObject.Instantiate(rowTiles[row], (position + new Vector3(0, 0, i)), Quaternion.identity));
        }
    }

    public void DestroyRow(int row) //Removes the designated row
    {
        for (int i = 0; i < instancedCell.Count; i++)
        {
            GameObject.Destroy(instancedCell[i]);
        }
    }
    //////////
}
