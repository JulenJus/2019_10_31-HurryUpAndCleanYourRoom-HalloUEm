using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Large : Room
{
    private readonly Vector3 gravityVector = new Vector3(0, -1, 0);
    [SerializeField] private float zDistance = 7.26f;

    public override Vector3 getGravityVector()
    {
        return gravityVector;
    }

    public override float getZDistance()
    {
        return zDistance;
    }
}
