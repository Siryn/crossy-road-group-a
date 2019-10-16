using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Row
{
    ////////////
    // VARIABLES
    ////////////
    public GameObject[] rowTiles = new GameObject[5];
    public GameObject[] cellProps = new GameObject[8];
    private List<GameObject> instancedCell = new List<GameObject>();
    private List<GameObject> instancedGrass = new List<GameObject>();
    private List<GameObject> instancedRoad = new List<GameObject>();
    private List<GameObject> instancedWater = new List<GameObject>();
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
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
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
    //////////
}

public class Grass
{
    ////////////
    // VARIABLES
    ////////////

    ////////////

    /////////////
    // Properties
    /////////////

    /////////////

    ///////////////
    // CONSTRUCTORS
    ///////////////
    public Grass(int gen)
    {
        switch (gen)
        {
            case 0:
                SpawnEmpty();
                break;
            case 1:
                SpawnFull();
                break;
            case 2:
                SpawnRandom();
                break;
            default:
                break;
        }
    }
    ///////////////

    //////////
    // METHODS
    //////////
    public void SpawnEmpty()
    {

    }

    public void SpawnFull()
    {

    }

    public void SpawnRandom()
    {

    }
    //////////
}

public class Road
{
    ////////////
    // VARIABLES
    ////////////

    ////////////

    /////////////
    // Properties
    /////////////

    /////////////

    ///////////////
    // CONSTRUCTORS
    ///////////////
    public Road(int gen)
    {
        switch (gen)
        {
            case 0:
                SpawnCar();
                break;
            case 1:
                SpawnSemi();
                break;
            case 2:
                SpawnPotHole();
                break;
            default:
                break;
        }
    }
    ///////////////

    //////////
    // METHODS
    //////////
    public void SpawnCar()
    {

    }

    public void SpawnSemi()
    {

    }

    public void SpawnPotHole()
    {

    }
    //////////
}

public class Water
{
    ////////////
    // VARIABLES
    ////////////

    ////////////

    /////////////
    // Properties
    /////////////

    /////////////

    ///////////////
    // CONSTRUCTORS
    ///////////////
    public Water(int gen)
    {
        switch (gen)
        {
            case 0:
                SpawnLilyPad();
                break;
            case 1:
                SpawnBoat();
                break;
            case 2:
                SpawnGeyser();
                break;
            default:
                break;
        }
    }
    ///////////////

    //////////
    // METHODS
    //////////
    public void SpawnLilyPad()
    {

    }

    public void SpawnBoat()
    {

    }

    public void SpawnGeyser()
    {

    }
    //////////
}