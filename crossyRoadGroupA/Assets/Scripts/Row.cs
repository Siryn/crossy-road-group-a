using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row
{
    ////////////
    // VARIABLES
    ////////////
    public GameObject[] rowTiles = new GameObject[3];
    public GameObject[] cellProps = new GameObject[8];
    private List<GameObject> instancedCell = new List<GameObject>();
    private List<GameObject> listMeshes = new List<GameObject>();
    private List<Obstacle> listObstacles = new List<Obstacle>();
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
    public Row(GameObject[] tiles, GameObject[] props, int row, int gen, Vector3 position)
    {
        rowTiles = tiles;
        cellProps = props;
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

            switch (row)
            {
                case 0:
                    SpawnforGrass(gen, position, i);
                    break;
                case 1:
                    SpawnforRoad(gen, position, i);
                    break;
                case 2:
                    SpawnforWater(gen, position, i);
                    break;
                default:
                    break;
            }
        }
    }

    public void DestroyRow(int row) //Removes the designated row
    {
        for (int i = 0; i < instancedCell.Count; i++)
        {
            GameObject.Destroy(instancedCell[i]);
        }
    }

    public void SpawnforGrass(int gen, Vector3 position, int i)
    {
        switch (gen)
        {
            case 0:
                break;
            case 1:
                if (position.z + i != 0)
                {
                    if (Random.value <= .33f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[0], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                    else if (Random.value >= .66f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[1], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                    else
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[2], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                }
                break;
            case 2:
                if (position.z + i != 0 && Random.value <= .25f)
                {
                    if (Random.value <= .33f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[0], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                    else if (Random.value >= .66f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[1], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                    else
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[2], position + new Vector3(0, .1f, i), Quaternion.identity));
                    }
                }
                break;
            default:
                break;
        }
    }

    public void SpawnforRoad(int gen, Vector3 position, int i)
    {
        switch (gen)
        {
            case 0:
                //SpawnCar
                break;
            case 1:
                //SpawnSemi
                break;
            case 2:
                if (position.z + i != 0 && Random.value <= .25f)
                {
                    listMeshes.Add(GameObject.Instantiate(cellProps[5], position + new Vector3(0, .05f, i), Quaternion.identity));
                }
                break;
            default:
                break;
        }
    }

    public void SpawnforWater(int gen, Vector3 position, int i)
    {
        switch (gen)
        {
            case 0:
                if (position.z + i == 0)
                {
                    listMeshes.Add(GameObject.Instantiate(cellProps[6], position + new Vector3(0, .05f, i), Quaternion.identity));
                }
                else
                {
                    if (Random.value <=.25f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[6], position + new Vector3(0, .05f, i), Quaternion.identity));
                    }
                }
                break;
            case 1:
                if (i % 5 == 0)
                {
                    listMeshes.Add(GameObject.Instantiate(cellProps[7], position + new Vector3(0, .05f, i), Quaternion.identity));
                }
                break;
            case 2:
                if (position.z + i == 0)
                {
                    listMeshes.Add(GameObject.Instantiate(cellProps[6], position + new Vector3(0, .05f, i), Quaternion.identity));
                }
                else
                {
                    if (Random.value <= .25f)
                    {
                        listMeshes.Add(GameObject.Instantiate(cellProps[6], position + new Vector3(0, .05f, i), Quaternion.identity));
                    }
                }
                break;
            default:
                break;
        }
    }
    //////////
}