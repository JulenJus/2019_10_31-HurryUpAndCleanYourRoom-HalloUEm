using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    [SerializeField] private Vector3 iniZoomOutPosition;
    private static Vector3 zoomOutPosition;

    [SerializeField] private Room iniInitialRoom;
    private static Room initialRoom;

    [SerializeField] private float iniZDistance;
    private static float zDistance;

    public void Awake()
    {
        initialRoom = iniInitialRoom;
        zoomOutPosition = iniZoomOutPosition;
        zDistance = iniZDistance;
    }

    public void Start()
    {
        initialRoom.activate();
    }

    public static Vector3 getZoomOutPosition()
    {
        return zoomOutPosition;
    }

    public static Room getInitialRoom()
    {
        return initialRoom;
    }

    public static float getZDistance()
    {
        return zDistance;
    }
}
