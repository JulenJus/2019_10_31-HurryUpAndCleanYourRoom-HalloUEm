using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Wardrobe : Gate
{
    override public void arrive()
    {
        Player.setPosition(transform);
    }
}
