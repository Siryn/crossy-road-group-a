using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    public GameObject[] cellProps = new GameObject[8];
    private bool respawned = false;

    void Start()
    {
        cellProps = GameObject.FindGameObjectWithTag("generator").GetComponent<LevelGeneration>().cellProps;
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Random.Range(0.0f, 3.0f));
    }

    void Update()
    {
        transform.position = transform.localPosition + new Vector3(0, 0, Random.Range(0.005f, 0.025f));

        if (transform.position.z >= 7 && respawned == false)
        {
            GameObject.Instantiate(cellProps[3], transform.position - new Vector3(0, 0, 15), Quaternion.identity);
            respawned = true;
        }

        if (transform.position.z >= 10)
        {
            Destroy(gameObject);
        }

        if (GlobalVariables.playerXPosition - transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
