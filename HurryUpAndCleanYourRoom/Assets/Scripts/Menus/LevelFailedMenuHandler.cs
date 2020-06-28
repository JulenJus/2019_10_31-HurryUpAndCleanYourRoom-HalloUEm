using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailedMenuHandler : MonoBehaviour
{
    [SerializeField] public static int level = 1;

    public void restart()
    {
        Application.LoadLevel("Level" + LevelCompletedMenuHandler.level);
    }

    public void exitToMenu()
    {
        Application.LoadLevel("MainMenu");
        LevelCompletedMenuHandler.level = 1;
    }
}
