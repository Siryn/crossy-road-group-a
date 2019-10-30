using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    public GameObject[] cellProps = new GameObject[8];
    private bool respawned = false;

    void Start()
    {
        cellProps = GameObject.FindGameObjectWithTag("generator").GetComponent<LevelGeneration>().cellProps;
        transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Random.Range(0.0f, 1.0f));
    }

    void Update()
    {
        transform.position = transform.localPosition - new Vector3(0, 0, Random.Range(0.005f, 0.025f));

        if (transform.position.z <= -7 && respawned == false)
        {
            GameObject.Instantiate(cellProps[7], transform.position + new Vector3(0, 0, 15), Quaternion.identity);
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

        /*private bool changeDirection = false;

        private void Awake()
        {
            if (Random.value < 0.5f)
            {
                changeDirection = true;
            }
        }

        void Start()
        {
            if (changeDirection == true)
            {
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - Random.Range(20, 25));
            }
            else
            {
                transform.position = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + Random.Range(0, 5));
            }
        }

        void Update()
        {
            if (changeDirection == true)
            {
                transform.position = transform.localPosition + new Vector3(0, 0, Random.Range(0.005f, 0.025f));
            }
            else
            {
                transform.position = transform.localPosition - new Vector3(0, 0, Random.Range(0.005f, 0.025f));
            }

            if (transform.position.z >= 10 || transform.position.z <= -10)
            {
                Destroy(gameObject);
            }
        }*/
    }
