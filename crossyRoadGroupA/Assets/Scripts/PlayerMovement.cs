using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool moving = false;

    //this changes the speed the player moves from each block.
    private float animationTimer = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(0, 0, 1f), animationTimer));
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(-1f, 0, 0), animationTimer));
        }

        //We need to make it so that the player can only go backwards 2 or 3 times so that we can destroy the geometry further back than that.
        //In order to do this, we will need to track how many times the player has gone backwards from his *current lane*.
        //Otherwise, we could do a simple counter where reaching 3 deactivates S, and pressing W gives you steps back...
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(0, 0, -1f), animationTimer));
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(1f, 0, 0), animationTimer));
        }
    }

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time)
    {
        if (!moving)
        { // do nothing if already moving
            moving = true; // signals "I'm moving, don't bother me!"
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
                transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t
                yield return 0; // leave the routine and return here in the next frame
            }
            moving = false; // finished moving
        }
    }
}
