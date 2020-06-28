using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private const string zoomInKey = "j";

    [SerializeField] private const string zoomMediumKey = "k";

    private static int mediumOffset;
    [SerializeField] private int iniMediumOffset= 5;

    [SerializeField] private const string zoomOutKey = "l";

    private static int cameraMode = 3; //1=in, 2=medium, 3=out
    private Camera camera;

    //Camera transition variables
    private static bool moveCamera = false;
    private static Vector3 tarjet;
    private static float distance;
    [SerializeField] private const float minDistance = 0.1f;
    [SerializeField] private const float step = 0.01f;
    private static float fractionateDistance= 10.0f;
    private static float fractionatePlayerDistance = 120.0f;

    private static float zTarjetDistance;
    private static float zDistance;
    private static bool cameraZarrived = true;

    //Camera rotation variables
    private static bool rotate = false;
    private static Quaternion newRotation;
    [SerializeField] private bool rotationAble = false;

    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        mediumOffset = iniMediumOffset;
    }

    // Update is called once per frame
    void Update()
    {
        //Es super ineficiente
        if (Input.GetKeyDown(zoomInKey))
        {
            zoomIn();
        }
        else if (Input.GetKeyDown(zoomMediumKey))
        {
            zoomMedium();
        }
        else if (Input.GetKeyDown(zoomOutKey))
        {
            zoomOut();
        }
        

        //Cambiar pos camara
        if (moveCamera)
        {
            Vector3 disVec = tarjet - transform.position;
            disVec = new Vector3(disVec.x, disVec.y,0);
            distance = Vector3.Magnitude(disVec);

            if (distance > minDistance)
            {
                transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -20), 
                    new Vector3(tarjet.x, tarjet.y, -20), 
                    Mathf.Max(step, distance/fractionateDistance)); //Ojo coordenada z puede hacer que no llegues nunca
            }

            if (!cameraZarrived)
            {
                if (Mathf.Abs(zTarjetDistance - zDistance) < minDistance)
                {
                    cameraZarrived = true;
                }
                else
                {
                    camera.orthographicSize += Mathf.Sign(zTarjetDistance - zDistance) * Mathf.Max(step, 
                        Mathf.Abs(zTarjetDistance-zDistance)/fractionateDistance);
                    zDistance = camera.orthographicSize;
                }
            }

            if(distance < minDistance && cameraZarrived)
            {
                moveCamera = false;
            }
        }

        if(cameraMode==2 && !moveCamera)
        {
            //Seguir al jugador con la cámara
            float playerDistance = Vector3.Magnitude(Player.getPosition() - transform.position);
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -20),
                                                    new Vector3(Player.getPosition().x, transform.position.y, -20),
                                                       Mathf.Max(step, playerDistance / fractionatePlayerDistance));
        }

        //Rotate¿?

        if (rotationAble && rotate)
        {
            transform.rotation = newRotation;
            rotate = false;
        }
    }

    public static void zoomIn()
    {
        //Debug.Log("Zoom in");
        cameraMode = 1;

        moveCamera = true;
        cameraZarrived = false;

        zTarjetDistance = LevelState.getCurrentRoom().getZDistance();
        //Debug.Log(zTarjetDistance);

        tarjet = LevelState.getCurrentRoom().transform.position;
    }

    public static void zoomMedium()
    {
        //Mover, no teletransportar
        //Debug.Log("Zoom Medium");
        cameraMode = 2;

        moveCamera = true;
        cameraZarrived = false;

        zTarjetDistance = LevelState.getCurrentRoom().getZDistance();
        zTarjetDistance += mediumOffset;
        //Debug.Log(zTarjetDistance);

        tarjet = LevelState.getCurrentRoom().transform.position;
    }

    public static void zoomOut()
    {
        //Mover, no teletransportar
        //Debug.Log("Zoom Out");
        cameraMode = 3;

        moveCamera = true;
        cameraZarrived = false;

        zTarjetDistance = House.getZDistance();
        //Debug.Log(zTarjetDistance);

        tarjet = House.getZoomOutPosition();
    }

    public static void changeRoom(int roomID)
    {
        if (cameraMode != 3)
        {
            if (cameraMode == 1)
            {
                zoomIn();
            }
            else
            {
                zoomMedium();
            }
        }
    }

    public static void setRotation(Quaternion rotation)
    {
        //Debug.Log("NewRotation: " + rotation.eulerAngles.z);
        //Debug.Log("ActualRotation: " + newRotation.eulerAngles.z);
        //Debug.Log(rotation.eulerAngles.z - newRotation.eulerAngles.z);
        //float diference = Mathf.Abs(rotation.eulerAngles.z - newRotation.eulerAngles.z);
        if ((int)rotation.eulerAngles.z == 180)
        {
            if((int)newRotation.eulerAngles.z == 0)
            {
                //Debug.Log("rotaa");
                newRotation = rotation;
                rotate = true;
            }
        }
        else if((int)rotation.eulerAngles.z ==0)
        {
            if ((int)newRotation.eulerAngles.z == 180)
            {
                //Debug.Log("rotaa");
                newRotation = rotation;
                rotate = true;
            }
        }
    }
}
