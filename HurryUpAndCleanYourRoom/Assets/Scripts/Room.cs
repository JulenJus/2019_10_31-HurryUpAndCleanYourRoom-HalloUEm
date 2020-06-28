using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    private bool visited = false;
    private Vector3 gravityDirection;
    private int roomID;
    [SerializeField] private SpriteRenderer blackCourtain;

    private bool ocuped = false;

    public void Awake()
    {
        deactivate();
    }

    public void activate()
    {
        ocuped = true;
        visited = true;
        blackCourtain.enabled = false;
        //Debug.Log("Activate(" + roomID + "): " + ocuped);
    }

    public void deactivate()
    {
        //Debug.Log("Deactivate("+ roomID+"): " + ocuped);
        if (!ocuped) {
            visited = false;
            blackCourtain.enabled = true;
        }
    }

    public void chanceOfDeactivation()
    {
        if (LevelState.hasDeactivatedSystem())
        {
            if (Random.value < LevelState.getDeactivationProbability())
            {
                StartCoroutine(deactivationTimer());
            }
        }
    }

    public abstract Vector3 getGravityVector();
    public abstract float getZDistance();

    //Getters
    public bool isVisited()
    {
        return visited;
    }

    public int getRoomID()
    {
        return roomID;
    }

    public bool getOcuped()
    {
        return ocuped;
    }

    //Setters
    public void setRoomID(int id)
    {
        roomID = id;
    }

    public void setOcuped(bool ocuped)
    {
        this.ocuped = ocuped;
    }

    //Coroutine
    IEnumerator deactivationTimer()
    {
        yield return new WaitForSeconds(Random.value*5);
        deactivate();
    }
}
