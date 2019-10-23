using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pothole : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        transform.localScale = new Vector3(Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f), Random.Range(1.0f, 2.0f));
    }
}
