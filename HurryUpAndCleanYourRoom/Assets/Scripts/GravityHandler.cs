using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHandler : MonoBehaviour
{
    private static Vector3 gravityDirection;
    private static float gravityVelocity = 9.8f;

    public void Start()
    {
        setGravity(new Vector3(0, -1, 0));
    }

    public static void setGravity(Vector3 dir)
    {
        gravityDirection = Vector3.Normalize(dir);
        //Debug.Log("holoi");
    }

    public static Vector3 getGravityDirection()
    {
        return gravityDirection;
    }

    public static float getGravityVelocity()
    {
        return gravityVelocity;
    }
}
