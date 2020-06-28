using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompletedMenuHandler : MonoBehaviour
{
    [SerializeField] public static int level = 1;

    public void nextLevel()
    {
        level++;
        if (level == 5)
        {
            Application.LoadLevel("EndScene");
        }
        else { 
            Application.LoadLevel("Level" + level);
        }
    }

    public void exitToMenu()
    {
        Application.LoadLevel("MainMenu");
        level = 1;
    }
}
