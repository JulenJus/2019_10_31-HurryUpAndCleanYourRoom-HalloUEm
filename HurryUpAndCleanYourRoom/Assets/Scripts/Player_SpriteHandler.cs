using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SpriteHandler : MonoBehaviour
{
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a")){
            sprite.flipX=true;
            //Mover gif
        }
        else if (Input.GetKey("d"))
        {
            sprite.flipX = false;
            //Mover gif
        }
        else
        {
            //imagen estática
        }
    }
}
