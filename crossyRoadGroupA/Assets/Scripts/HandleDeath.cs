using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleDeath : MonoBehaviour
{
    public GameObject UIgo;
    public UIController handleDeath;

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
    }
}
