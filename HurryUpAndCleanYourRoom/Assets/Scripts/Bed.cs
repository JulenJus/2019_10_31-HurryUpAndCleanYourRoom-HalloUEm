using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Interactuable
{
    public override void interactuate()
    {
        LevelState.levelCompleted();
    }
}
