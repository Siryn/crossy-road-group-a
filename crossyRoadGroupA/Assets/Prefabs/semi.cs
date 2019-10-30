using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semi : MonoBehaviour
{
    public GameObject[] cellProps = new GameObject[8];
    private bool respawned = false;

    void Start()
    {
        cellProps = GameObject.FindGameObjectWithTag("generator").GetComponent<LevelGeneration>().cellProps;
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Random.Range(0.0f, 2.0f));
    }

    void Update()
    {
        transform.position = transform.localPosition - new Vector3(0, 0, Random.Range(0.0025f, 0.01f));

        if (transform.position.z <= -7 && respawned == false)
        {
            GameObject.Instantiate(cellProps[4], transform.position + new Vector3(0, 0, 15), Quaternion.identity);
            respawned = true;
        }

        if (transform.position.z <= -10)
        {
            Destroy(gameObject);
        }

        if (GlobalVariables.playerXPosition - transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
