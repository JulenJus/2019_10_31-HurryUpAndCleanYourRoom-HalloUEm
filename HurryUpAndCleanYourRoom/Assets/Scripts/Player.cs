using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private static GameObject player;

    //Interactuate variables
    [SerializeField] private const string interactuateChar = "i";
    [SerializeField] private static GameObject hintInteractuate;

    //Movement variables
    private Vector3 movement = Vector3.zero;
    [SerializeField] private CharacterController controller;
    private readonly int playerSpeed = 10;
    [SerializeField] private float walkSpeed = 40.0f;
    private float horizontalMove = 0f;

    //Gravity variables
    private static GravityHandler gravity;
    private static Vector2 gravityMovement;

    ///
    public void Awake()
    {
        player = GameObject.Find("Player");
        controller = GetComponent<CharacterController>();
        hintInteractuate = GameObject.Find("hintInteractuate");
        gravity = GetComponent<GravityHandler>();
    }

    public void Start()
    {
        hintInteractuate.SetActive(false);
    }

    public void Update()
    {
        gravityMovement = GravityHandler.getGravityDirection() * GravityHandler.getGravityVelocity();
        controller.Move(gravityMovement * Time.deltaTime);
        //Debug.Log(gravityMovement);

        if (Input.GetKey("a") || Input.GetKey("d"))
        {
            movement = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            movement = transform.TransformDirection(movement);              //From local to global coordinates
            movement *= playerSpeed;

            controller.Move(movement * Time.deltaTime);                     //Time.deltaTime para que no dependa de fps
        }
    }

    //Setters
    public static void setPosition(Transform t)
    {
        player.GetComponent<CharacterController>().enabled = false;

        //Esperar a que la animación del objeto haya terminado

        player.transform.position = t.position;

        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x,
                                                    player.transform.eulerAngles.y,
                                                    t.eulerAngles.z);

        player.GetComponent<CharacterController>().enabled = true;
    }

    //Getters
    public static Vector3 getPosition()
    {
        return player.transform.position;
    }

    //Interaction Methods
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactive")
        {
            hintInteractuate.SetActive(true);
            //Change object's sprite (?)
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactive")
        {
            hintInteractuate.SetActive(false);
            //Change object's sprite (?)
        }
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.tag == "Interactive")
        {

            if (Input.GetKeyDown(interactuateChar))
            {
                Interactuable obj=(Interactuable)(other.GetComponent<Interactuable>());
                obj.interactuate();
            }
        }
    }


}
