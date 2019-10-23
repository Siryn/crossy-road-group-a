using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        transform.localScale = new Vector3(Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f), Random.Range(0.75f, 1.25f));
    }
}
