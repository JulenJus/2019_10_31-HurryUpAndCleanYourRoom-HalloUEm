using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate_Hatch : Gate
{
    override public void arrive()
    {
        Player.setPosition(transform);
    }
}
