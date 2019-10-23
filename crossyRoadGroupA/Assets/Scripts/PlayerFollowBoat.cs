using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowBoat : MonoBehaviour
{
    public GameObject boat;
    public HandleDeath moveWithBoat;
    // Start is called before the first frame update
    void Start()
    {
        moveWithBoat = GameObject.FindGameObjectWithTag("Player").GetComponent<HandleDeath>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveWithBoat.onBoat == true)
        {
            transform.position = new Vector3(boat.transform.position.x, 0, boat.transform.position.z - moveWithBoat.offset);
        }
    }

    public void MovePlayerWithBoat()
    {

    }
}
