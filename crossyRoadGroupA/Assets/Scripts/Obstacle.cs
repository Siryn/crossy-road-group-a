using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle
{
    public Obstacle(GameObject[] props, Vector3 position, int i)
    {

    }
}

public class LilyPad : Obstacle
{
    GameObject prop;

    public LilyPad(GameObject[] props, Vector3 position, int i) : base(props, position, i)
    {
        prop = GameObject.Instantiate(props[6], position + new Vector3(0, 0, i), Quaternion.identity);
        prop.tag = "lilypad";
    }
}

public class Boat : Obstacle
{
    public Boat(GameObject[] props, Vector3 position, int i) : base(props, position, i)
    {

    }
}

public class Geyser : Obstacle
{
    public Geyser(GameObject[] props, Vector3 position, int i) : base(props, position, i)
    {

    }
}

public class Car : Obstacle
{
    public Car(GameObject[] props, Vector3 position, int i) : base(props, position, i)
    {

    }
}

public class Semi : Obstacle
{
    public Semi(GameObject[] props, Vector3 position, int i) : base(props, position, i)
    {

    }
}