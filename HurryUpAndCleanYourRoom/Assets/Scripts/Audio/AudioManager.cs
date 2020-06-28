using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static bool done = false;
    private static AudioSource ost;
    // Start is called before the first frame update
    void Awake()
    {
        ost = GetComponent<AudioSource>();
        if (!done)
        {
            ost.Play();
            DontDestroyOnLoad(transform.gameObject);
            done = true;
        }
        
    }
}
