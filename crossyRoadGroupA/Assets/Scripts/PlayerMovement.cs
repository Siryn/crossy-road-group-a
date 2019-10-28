using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public bool moving = false;
    private bool facingBackwards = false;
    private bool keyPressed = false;

    //this changes the speed the player moves from each block.
    private float animationTimer = 0.3f;

    public Animator anim;

    public GameObject gruntModel;

    private int currentPosition = 0;

    public Quaternion gruntStartingRotation;

    public LevelGeneration levelGenerationScript;

    private Vector3 forward;
    private void Awake()
    {
        gruntStartingRotation = gruntModel.transform.rotation;

        forward = transform.TransformDirection(Vector3.forward);
    }
    private void Update()
    {

        if (Physics.Raycast(transform.position, forward, 1))
        {
            //print("there's something there!");
        }

        if (Input.GetKeyDown(KeyCode.W) && !moving)
        {
            facingBackwards = false;
            gruntModel.transform.rotation = gruntStartingRotation;

            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(1f, 0, 0), animationTimer));
            currentPosition++;
            if (currentPosition > GlobalVariables.playerXPosition)
            {
                GlobalVariables.playerXPosition++;
            }
  
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            facingBackwards = false;
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(0, 0, 1f), animationTimer));

            gruntModel.transform.rotation = gruntStartingRotation;

            if (!facingBackwards)
            {
                gruntModel.transform.Rotate(0, -90, 0);
            }
            else
            {
                gruntModel.transform.Rotate(0, 90, 0);
            }

        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            //prevents player from moving farther than 3 spaces backward
            if (currentPosition <= (GlobalVariables.playerXPosition - 3))
            {
                print("you can't move farther back!");

            }
            else
            {
                if (!facingBackwards)
                {
                    facingBackwards = true;
                    gruntModel.transform.rotation = gruntStartingRotation;
                    gruntModel.transform.Rotate(0, 180, 0);
                }


                StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(-1f, 0, 0), animationTimer));
                currentPosition--;
                print("current position: " + currentPosition);

            }
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            facingBackwards = false;
            StartCoroutine(MoveFromTo(transform.position, transform.position + new Vector3(0, 0, -1f), animationTimer));

            gruntModel.transform.rotation = gruntStartingRotation;

            if (!facingBackwards)
            {
                gruntModel.transform.Rotate(0, 90, 0);
            }
            else
            {
                gruntModel.transform.Rotate(0, -90, 0);
            }
        }

    }

    IEnumerator MoveFromTo(Vector3 pointA, Vector3 pointB, float time)
    {
        if (!moving)
        { // do nothing if already moving
            moving = true; // "I'm moving, don't bother me!"
            anim.SetBool("moving", true);
            float t = 0f;
            while (t < 1f)
            {
                t += Time.deltaTime / time; // sweeps from 0 to 1 in time seconds
                transform.position = Vector3.Lerp(pointA, pointB, t); // set position proportional to t

                if (GlobalVariables.playerXPosition == (GlobalVariables.currentMaxRow - 3))
                {
                    GlobalVariables.currentMaxRow++;
                }

                if (GlobalVariables.playerXPosition == GlobalVariables.generationThreshold)
                {
                    levelGenerationScript.RemoveSafeZone();
                }

                if (levelGenerationScript.rowList.Count <= GlobalVariables.currentMaxRow + GlobalVariables.generationThreshold)
                {
                    levelGenerationScript.AddRow();
                }

                if (GlobalVariables.currentMaxRow > GlobalVariables.generationThreshold + levelGenerationScript.offsetSafeX)
                {
                    int i = GlobalVariables.playerXPosition - GlobalVariables.generationThreshold + 1;
                    levelGenerationScript.rowList[i].DestroyRow(i);
                }

                yield return 0; // leave the routine and return here in the next frame
            }
            moving = false; // finished moving
            anim.SetBool("moving", false);
        }
    }
}


