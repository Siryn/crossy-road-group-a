using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    private Transform player;

    private bool touchingPlayer;

    private UIController UIController;

    // Start is called before the first frame update
    void Start()
    {
        UIController = GameObject.FindGameObjectWithTag("UIController").GetComponent<UIController>();

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x == transform.position.x)
        {
            if (player.position.y == transform.position.y)
            {
                touchingPlayer = true;
                print("player is wet now");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("boat"))
        {
            if (touchingPlayer)
            {
                print("safe");
            }
            else
            {
                UIController.OnDeathEvent();
            }
        }
    }
}
