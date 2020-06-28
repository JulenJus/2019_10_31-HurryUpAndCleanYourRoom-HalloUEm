using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHandler : MonoBehaviour
{
    public void exitGame()
    {
        Application.Quit();
    }

    public void play()
    {
        Application.LoadLevel("Level1");
    }
}
