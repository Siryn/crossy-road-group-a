using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lilypad : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        transform.localScale = new Vector3(Random.Range(0.75f, 1.25f), 1, Random.Range(0.75f, 1.25f));
    }

    void Update()
    {
        transform.Rotate(0, 30 * Time.deltaTime, 0);

        if (GlobalVariables.playerXPosition - transform.position.x >= 15)
        {
            Destroy(gameObject);
        }
    }
}
