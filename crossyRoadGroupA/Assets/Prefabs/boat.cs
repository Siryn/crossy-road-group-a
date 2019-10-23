using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boat : MonoBehaviour
{
    private bool changeDirection = false;

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
    }
}
