using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public UIController UIController;

    public bool onBoat = false;
    public GameObject boat;
    public float offset;

    private bool safeChecker = false;

    // Start is called before the first frame update
    void Start()
    {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathBox"))
        {
            UIController.OnDeathEvent();
            print("DEATH");
        }

        if (other.CompareTag("boat"))
        {
            print("no death");
            safeChecker = true;
            //return;
        }

        if (other.CompareTag("water"))
        {
            //print("boat collition");
            //offset = boat.transform.position.z - transform.position.z;
            //offset = Mathf.RoundToInt(offset);
            //return;
            if (!safeChecker)
            {
                UIController.OnDeathEvent();
                print("death by water");
            }


        }

    }

    private void OnTriggerExit(Collider other)
    { 

        if (other.CompareTag("water"))
        {
            if (safeChecker)
            {
                UIController.OnDeathEvent();
                print("death by water 2");
            }
        }

        if (other.CompareTag("boat"))
        {
            safeChecker = false;
            print("bye bye");
        }
    }
}
