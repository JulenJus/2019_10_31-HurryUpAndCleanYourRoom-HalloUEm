using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] private float levelTime;
    private float currentTime;
    [SerializeField] Image remainingTime;
    
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (LevelState.isPlaying()) {
            currentTime += Time.deltaTime;
            remainingTime.fillAmount = (levelTime - currentTime) / levelTime;

            if (currentTime > levelTime)
            {
                currentTime = 0;
                LevelState.levelFailed();
            }
        }
    }
}
