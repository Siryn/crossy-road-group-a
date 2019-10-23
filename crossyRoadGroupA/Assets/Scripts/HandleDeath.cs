using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public UIController handleDeath;

    private bool onBoat = false;

    // Start is called before the first frame update
    void Start()
    {
        handleDeath = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DeathBox"))
        {
            handleDeath.OnDeathEvent();
            print("DEATH");
        }

        if (other.CompareTag("boat"))
        {
            onBoat = true;

            print("boat collition");
            return;
        }

        if (other.CompareTag("water"))
        {
            if (onBoat == false)
            {
                handleDeath.OnDeathEvent();
                print("DEATH");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("boat"))
        {
            onBoat = false;
        }
    }
}
