using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelState : MonoBehaviour
{
    //Current game info
    private static int currentRoomID;
    [SerializeField] private Room[] iniRooms;
    [SerializeField] private static Room[] rooms;
    private static bool playing = true;
    private static bool completed = false;

    //Level info
    [SerializeField] private bool inideactivationSystem = false;
    private static bool deactivationSystem = false;

    [SerializeField] private float iniDeactivationProbability=0.10f;
    private static float deactivationProbability=0.10f;

    [SerializeField] private static string nextLevel;
    [SerializeField] private string iniNextLevel;

    public void Awake()
    {
        rooms = iniRooms;   //Esto es una guarrada XDDDDD
        nextLevel = iniNextLevel;   //Y OTRAAA
        deactivationSystem = inideactivationSystem;   //VAMOS QUE VAMOS PARA LINEAAAA
        deactivationProbability = iniDeactivationProbability; //Y BINGOOOOO

        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i].setRoomID(i);
        }
    }

    public void Start()
    {
        changeRoom(House.getInitialRoom().getRoomID());
        LevelState.playing = true;
    }


    public static void changeRoom(int roomID)
    {
        rooms[currentRoomID].setOcuped(false);
        //Debug.Log("LevelState ("+ currentRoomID+"): " + rooms[currentRoomID].getOcuped());
        if (rooms[currentRoomID] != House.getInitialRoom())
        {
            rooms[currentRoomID].chanceOfDeactivation();
        }


        setCurrentRoom(roomID);

        rooms[roomID].activate();
        
        CameraHandler.changeRoom(roomID);
        //GravityHandler.setGravity(rooms[currentRoomID].getGravityVector());
    }

    //Setters
    public static void setCurrentRoom(int roomID)
    {
        currentRoomID = roomID;
    }

    public static void levelCompleted()
    {
        playing = false;
        completed = true;
        //Si queremos mostrar algo rollo animación, se pondría aquí

        //Pasar al siguiente nivel
        if(nextLevel == "EndScene")
        {
            Application.LoadLevel("EndScene");
        }
        else
        {
            Application.LoadLevel("LevelCompletedMenu");
        }

    }

    public static void levelFailed()
    {
        playing = false;
        //Show YOU LOOOOSE message
        //Debug.Log("Perdíste wey");
        Application.LoadLevel("LevelFailedMenu");
    }

    //Getters
    public static Room getCurrentRoom()
    {
        return rooms[currentRoomID];
    }

    public static bool isPlaying()
    {
        return playing;
    }

    public static bool hasDeactivatedSystem()
    {
        return deactivationSystem;
    }

    public static float getDeactivationProbability()
    {
        return deactivationProbability;
    }
}
