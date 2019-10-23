using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geyser : MonoBehaviour
{
    void Awake()
    {
        transform.Rotate(0.0f, Random.Range(0.0f, 360.0f), 0.0f);
        transform.localScale = new Vector3(Random.Range(1.0f, 1.5f), 1, Random.Range(1.0f, 1.5f));
    }

    void Start()
    {
        StartCoroutine(GeyserCR());
    }

    void Update()
    {
        transform.Rotate(0, 45 * Time.deltaTime, 0);
    }

    IEnumerator GeyserCR()
    {
        //while (Vector3.Distance(transform.localPosition, transform.localPosition + new Vector3(0, 0.25f, 0)) > 0.05f)
        while (transform.localPosition.y < 0.2f)
        {
            transform.position = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, 0.25f, transform.localPosition.z), Time.deltaTime);

            yield return null;
        }

        //while (Vector3.Distance(transform.localPosition + new Vector3(0, 0.25f, 0), transform.localPosition) > 0.05f)
        while (transform.localPosition.y > 0.0f)
        {
            transform.position = Vector3.Lerp(transform.localPosition, new Vector3(transform.localPosition.x, 0.0f, transform.localPosition.z), Time.deltaTime);

            yield return null;
        }

        yield return new WaitForSeconds(3f);
    }
}
