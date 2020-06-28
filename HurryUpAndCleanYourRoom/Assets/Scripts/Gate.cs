using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : Interactuable
{
    [SerializeField] private Gate destiny;
    private int roomID;

    public void Start()
    {
        roomID = transform.parent.GetComponent<Room>().getRoomID();
    }

    public virtual void arrive()
    {
        Player.setPosition(transform);
    }

    override public void interactuate()
    {
        LevelState.changeRoom(destiny.getRoom());
        destiny.arrive();
        GravityHandler.setGravity(Quaternion.Euler(destiny.transform.eulerAngles) * new Vector3(0, -1, 0));

        //
        CameraHandler.setRotation(Quaternion.Euler(0,0,destiny.transform.eulerAngles.z));
        //
    }

    public int getRoom()
    {
        return roomID;
    }
}
